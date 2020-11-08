
using System;
using WildFarm.Enumerators;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Mammels.Felines
{
    public class Tiger : Feline
    {
        private const double IncreaseWeight = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override string ProducingSound()
        {
            return "ROAR!!!";
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
