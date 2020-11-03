
namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int POWER = 100;

        public Paladin(string name)
        {
            Name = name;
            Power = POWER;
        }

        public override string Name { get; }
        public override int Power { get; }


        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
