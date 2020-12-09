using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private ICollection<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            Name = name;
            Energy = energy;

            instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set => energy = value < 0 ? 0 : value;
        }

        public ICollection<IInstrument> Instruments => instruments;


        public virtual void Work()
        {
            Energy -= 10;
        }


        public void AddInstrument(IInstrument instrument)
        {
            if (instrument != null)
            {
                instruments.Add(instrument);
            }
        }
    }
}
