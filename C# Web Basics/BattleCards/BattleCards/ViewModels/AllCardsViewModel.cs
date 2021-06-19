namespace BattleCards.ViewModels
{
    using System.Collections.Generic;

    public class AllCardsViewModel
    {
        public ICollection<CardViewModel> Cards { get; set; }
    }
}
