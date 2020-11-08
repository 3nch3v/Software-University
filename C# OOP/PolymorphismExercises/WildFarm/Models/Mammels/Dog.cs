
using System;
using WildFarm.Enumerators;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Mammels
{
    public class Dog : Mammal
    {
        private const double IncreaseWeight = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override string ProducingSound()
        {
            return "Woof!";
        }

        public override void FeedAnimal(Food food)
        {
            TigersDogOwlFood result;
            bool isParsed = Enum.TryParse<TigersDogOwlFood>(food.GetType().Name, out result);

            if (!isParsed)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * IncreaseWeight;
        }
    }
}
