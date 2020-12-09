
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            private set => power = value > 0 ? value : 0;
        }

        public void Use()
        {
            Power -= 10;
        }

        public bool IsBroken() => power == 0;
    }
}
