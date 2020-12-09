﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        protected Dwarf(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Instruments = new List<IInstrument>();
        }

        public string Name
        {
            get { return name;}
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
            get { return energy; }
            protected set
            {
                energy = value > 0 ? value : 0;
            }
        }

        public ICollection<IInstrument> Instruments { get; }


        public virtual void Work()
        {
            Energy -= 10;
        }


        public void AddInstrument(IInstrument instrument)
        {
            Instruments.Add(instrument);
        }

    }
}
