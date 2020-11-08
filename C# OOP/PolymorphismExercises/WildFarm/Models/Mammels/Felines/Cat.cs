
using System;
using WildFarm.Enumerators;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Mammels.Felines
{
    public class Cat : Feline
    {
        private const double IncreaseWeight = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override string ProducingSound()
        {
            return "Meow";
        }

        public override void FeedAnimal(Food food)
        {
            CatsFood result;
            bool isParsed = Enum.TryParse<CatsFood>(food.GetType().Name, out result);

            if (!isParsed)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * IncreaseWeight;
        }
    }
}
