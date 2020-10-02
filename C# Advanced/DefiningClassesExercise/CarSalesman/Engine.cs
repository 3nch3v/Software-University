
namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private string power;
        private string displacement;
        private string efficiency;

        public Engine(string model, string power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, string power, string displacement, string efficiency)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
        public string Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }
        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

    }
}
