using System;
using System.Collections.Generic;
using MilitaryElite.Enumerations;

namespace MilitaryElite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corp { get;  }
    }
}
