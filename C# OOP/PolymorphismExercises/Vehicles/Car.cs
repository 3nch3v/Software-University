
using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AIRCONDITIONER_COMSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double capacity)
            : base(fuelQuantity, fuelConsumption + AIRCONDITIONER_COMSUMPTION, capacity)
        {

        }
    }
}
