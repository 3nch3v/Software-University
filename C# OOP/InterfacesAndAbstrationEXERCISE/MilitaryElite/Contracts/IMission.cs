﻿
using MilitaryElite.Enumerations;

namespace MilitaryElite
{
    public interface IMission
    {
        string CodeName { get;  }

        State State { get;  }

        void CompleteMission();
    }
}
