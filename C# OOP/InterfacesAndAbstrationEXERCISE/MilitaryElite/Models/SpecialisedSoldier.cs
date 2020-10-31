
using System;
using System.Collections.Generic;
using MilitaryElite.Enumerations;
using MilitaryElite.Exeptions;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary)
        {
            Corp = TryParseCorps(corp);
        }


        public Corps Corp { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corp.ToString()}";
        }
    }
}