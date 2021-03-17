using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Models;

namespace CarDealer.DTO
{
    public class CarInputModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; } = new List<int>();
    }
}
