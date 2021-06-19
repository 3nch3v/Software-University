namespace BattleCards.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BattleCards.ViewModels;

    public interface ICardService
    {
        Task AddCard(CardInputModel input, string userId);

        Task AddToCollection(int cardId, string userId);

        Task RemoveFromCollection(int cardId, string userId);

        ICollection<string> CardValidation(CardInputModel input);

        ICollection<CardViewModel> GetAllCards();

        ICollection<CardViewModel> GetUsersCards(string userId);

        bool IsUserCollectionContainsCard(int cardId, string userId);
    }
}
