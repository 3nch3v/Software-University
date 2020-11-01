using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IAnimal cat = new Cat("Pesho", "Whiskas");
            IAnimal dog = new Dog("Gosho", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());

        }
    }
}
