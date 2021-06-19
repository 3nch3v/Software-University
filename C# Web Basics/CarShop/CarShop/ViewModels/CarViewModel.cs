using CarShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.ViewModels
{
    public class CarViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string PictureUrl { get; set; }

        public string PlateNumber { get; set; }

        public ICollection<Issue> Issues { get; set; }

        public int Fixed => Issues.Where(i => i.IsFixed == true).Count();

        public int NotFixed => Issues.Where(i => i.IsFixed == false).Count();
    }
}
