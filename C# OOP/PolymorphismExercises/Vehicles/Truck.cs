
using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AIRCONDITIONER_COMSUMPTION = 1.6;
        private static readonly double QTY_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double capacity) 
            : base(fuelQuantity, fuelConsumption + AIRCONDITIONER_COMSUMPTION, capacity)
        {

        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel * QTY_MODIFIER;
        }
    }
}
