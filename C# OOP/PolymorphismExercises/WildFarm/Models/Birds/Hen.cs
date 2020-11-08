using System;
using WildFarm.Enumerators;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Birds
{
    public class Hen : Bird
    {
        private const double IncreaseWeight = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override string ProducingSound()
        {
            return "Cluck";
        }

        public override void FeedAnimal(Food food)
        {
            HensFood result;
            bool isParsed = Enum.TryParse<HensFood>(food.GetType().Name, out result);

            if (!isParsed)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * IncreaseWeight;
        }
    }
}
