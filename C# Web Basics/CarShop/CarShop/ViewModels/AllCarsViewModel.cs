using System.Collections.Generic;

namespace CarShop.ViewModels
{
    public class AllCarsViewModel
    {
        public ICollection<CarViewModel> Cars { get; set; }
    }
}
