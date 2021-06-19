namespace BattleCards.Controllers
{
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using BattleCards.Services.Contracts;
    using BattleCards.ViewModels;

    public class CardsController : Controller
    {
        private readonly ICardService cardService;

        public CardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CardInputModel input)
        {
            var cardValidation = this.cardService.CardValidation(input);

            if (cardValidation.Any())
            {
                return Error(cardValidation);
            }

            var userId = this.User.Id;
            this.cardService.AddCard(input, userId);

            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var userCards = new AllCardsViewModel
            {
                Cards = this.cardService.GetAllCards(),
            };

            return this.View(userCards);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userCards = new AllCardsViewModel
            {
                Cards = this.cardService.GetUsersCards(this.User.Id),
            };

            return this.View(userCards);
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            if (this.cardService.IsUserCollectionContainsCard(cardId, this.User.Id))
            {
                return this.Redirect("/Cards/All");
            }

            this.cardService.AddToCollection(cardId, this.User.Id);

            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.cardService.IsUserCollectionContainsCard(cardId, this.User.Id))
            {
                return this.Redirect("/Cards/Collection");
            }

            this.cardService.RemoveFromCollection(cardId, this.User.Id);

            return this.Redirect("/Cards/Collection");
        }     
    }
}
