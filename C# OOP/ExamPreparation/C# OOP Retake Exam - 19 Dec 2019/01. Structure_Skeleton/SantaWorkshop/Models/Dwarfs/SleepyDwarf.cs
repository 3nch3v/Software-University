using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int INITIAL_ENERGY = 50;

        public SleepyDwarf(string name) 
            : base(name, INITIAL_ENERGY)
        {
        }

        public override void Work()
        {
            base.Work();
            Energy -= 5;
        }
    }
}
