
namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;

        public Warrior(string name)
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
