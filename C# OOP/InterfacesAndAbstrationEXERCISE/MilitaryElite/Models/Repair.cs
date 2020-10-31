
using System;

namespace MilitaryElite
{
    public class Repair : IRepair
    {
        public Repair(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }

        public string Name { get; private set; }
        public int Hours { get; private set; }


        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {Hours}";
        }
    }
}
