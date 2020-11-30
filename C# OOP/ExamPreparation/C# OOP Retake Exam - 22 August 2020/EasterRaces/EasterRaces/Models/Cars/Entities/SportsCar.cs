using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CUBICCENTIMETERS = 3000;
        private const int MIN_HORSE_POWER = 250;
        private const int MAX_HORSE_POWER = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CUBICCENTIMETERS, MIN_HORSE_POWER, MAX_HORSE_POWER)
        {

        }
    }
}
