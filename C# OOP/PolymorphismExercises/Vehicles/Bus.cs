using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AIRCONDITIONER_COMSUMPTION = 1.4;


        public Bus(double fuelQuantity, double fuelConsumption, double capacity) 
            : base(fuelQuantity, fuelConsumption, capacity)
        {

        }

        public override string Drive(double distance)
        {
            double restFuel = this.FuelQuantity - (distance * (this.FuelConsumption + AIRCONDITIONER_COMSUMPTION));

            if (restFuel < 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity = restFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double restFuel = this.FuelQuantity - (distance * this.FuelConsumption);

            if (restFuel < 0)
            {
                return $"Bus needs refueling";
            }

            this.FuelQuantity = restFuel;
            return $"Bus travelled {distance} km";
        }
    }
}
