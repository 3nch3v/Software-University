
using System;
using WildFarm.Enumerators;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Mammels
{
   public class Mouse : Mammal
    {
        private const double IncreaseWeight = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        public override string ProducingSound()
        {
            return "Squeak";
        }

        public override void FeedAnimal(Food food)
        {
            MiceFood result;
            bool isParsed = Enum.TryParse<MiceFood>(food.GetType().Name, out result);

            if (!isParsed)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * IncreaseWeight;
        }
    }
}
