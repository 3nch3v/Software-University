
namespace Raiding
{
    public abstract class BaseHero
    {
        public abstract string Name { get;  }

        public abstract int Power { get;  }

        public abstract string CastAbility();
    }
}
