using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public abstract class Animal
    {

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string ProducingSound();

        public abstract void FeedAnimal(Food food);


        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}";
        }
    }
}
