
using System;

namespace Animals
{
    public class Animal : IAnimal
    {
        public Animal(string name, string food)
        {
            this.Name = name;
            this.FavouriteFood = name;
        }


        public string Name { get; private set; }
        public string FavouriteFood { get; private set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
