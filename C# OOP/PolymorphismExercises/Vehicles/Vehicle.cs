
using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double capacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = capacity;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public double TankCapacity
        {
            get { return this.tankCapacity;}
            set
            {
                if (value < this.FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }

                this.tankCapacity = value;
            }
        }

        public virtual string Drive(double distance)
        {
            double restFuel = this.FuelQuantity - (distance * this.FuelConsumption);

            if (restFuel < 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity = restFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
