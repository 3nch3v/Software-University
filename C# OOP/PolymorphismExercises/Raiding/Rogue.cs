
namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;

        public Rogue(string name)
        {
            Name = name;
            Power = POWER;
        }

        public override string Name { get; }
        public override int Power { get; }


        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
