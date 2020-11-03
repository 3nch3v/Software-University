
namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;

        public Druid(string name)
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
