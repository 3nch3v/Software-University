namespace BattleCards.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BattleCards.Data.Models;
    using BattleCards.Services.Contracts;
    using BattleCards.ViewModels;
    using BattleCards.Data;

    using static BattleCards.Common.GlobalConstants;

    public class CardService : ICardService
    {
        private readonly ApplicationDbContext dbContext;

        public CardService(ApplicationDbContext dbContext)
        {

            this.dbContext = dbContext;
        }

        public async Task AddCard(CardInputModel input, string userId)
        {
            var card = new Card
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Attack = input.Attack,
                Keyword = input.Keyword,
                Description = input.Description,
                Health = input.Health,
            };

            card.UserCards.Add(new UserCard { UserId = userId });

            await this.dbContext.Cards.AddAsync(card);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddToCollection(int cardId, string userId)
        {
            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = userId,
            };

            await this.dbContext.UsersCards.AddAsync(userCard);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<string> CardValidation(CardInputModel input)
        {
            var errorList = new HashSet<string>();

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length > CardMaxLength || input.Name.Length < CardMinLength)
            {
                errorList.Add(string.Format(InvalidCardName, CardMinLength, CardMaxLength));
            }

            if (string.IsNullOrWhiteSpace(input.Image) || input.Image.Length > MaxImageUrlLength)
            {
                errorList.Add(InvalidImageUrl);
            }

            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                errorList.Add(IvalidKeyword);
            }

            if (input.Attack < 0)
            {
                errorList.Add(IvalidAttackRate);
            }

            if (input.Health < 0)
            {
                errorList.Add(IvalidHealthRate);
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length > DescriptionMaxLength)
            {
                errorList.Add(string.Format(InvalidDescriptionLength, DescriptionMinLength, DescriptionMaxLength));
            }

            return errorList;
        }

        public ICollection<CardViewModel> GetAllCards()
        {
            var cards = this.dbContext.Cards
                .Select(c => new CardViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    Id = c.Id,
                    Attack = c.Attack,
                    Health = c.Health,
                    ImageUrl = c.ImageUrl,
                    Keyword = c.Keyword,
                })
                .ToList();

            return cards;
        }

        public ICollection<CardViewModel> GetUsersCards(string userId)
        {
            var cardsIds = this.dbContext.UsersCards
              .Where(c => c.UserId == userId)
              .Select(c => c.CardId)
              .ToList();

            var userCards = this.dbContext.Cards
                .Where(c => cardsIds.Contains(c.Id))
                .Select(c => new CardViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    Id = c.Id,
                    Attack = c.Attack,
                    Health = c.Health,
                    ImageUrl = c.ImageUrl,
                    Keyword = c.Keyword,
                })
                .ToList();

            return userCards;
        }

        public bool IsUserCollectionContainsCard(int cardId, string userId)
        {
            var userCard = this.dbContext.UsersCards
                .Where(uc => uc.CardId == cardId && uc.UserId == userId)
                .Any();

            if (userCard)
            {
                return true;
            }

            return false;
        }

        public async Task RemoveFromCollection(int cardId, string userId)
        {
            var card = this.dbContext.UsersCards.First(c => c.CardId == cardId && c.UserId == userId);
            this.dbContext.UsersCards.Remove(card);

            await this.dbContext.SaveChangesAsync();
        }
    }
}