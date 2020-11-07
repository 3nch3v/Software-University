
namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConsumption;

        public override void Drive(double kilometers)
        {
            var fuelAfterDrive = this.Fuel - (kilometers * this.FuelConsumption);

            if (fuelAfterDrive >= 0)
            {
                this.Fuel = fuelAfterDrive;
            }
        }
    }
}
