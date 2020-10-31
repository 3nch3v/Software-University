
using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> PrivateUnderCommand { get; }

        void AddPrivate(ISoldier soldier);
    }
}
