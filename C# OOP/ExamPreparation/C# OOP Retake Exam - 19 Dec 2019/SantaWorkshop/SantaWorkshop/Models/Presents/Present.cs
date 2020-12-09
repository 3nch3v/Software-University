
using System;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private string name;
        private int energy;

        public Present(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                name = value;
            }
        }

        public int EnergyRequired
        {
            get => energy;
            private set => energy = value > 0 ? value : 0;
        }


        public void GetCrafted()
        {
            EnergyRequired -= 10;
        }

        public bool IsDone() => EnergyRequired == 0;
    }
}
