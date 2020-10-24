using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string comand;

            while ((comand = Console.ReadLine()) != "Beast!")
            {
                var currAnimalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = currAnimalArgs[0];
                int age = int.Parse(currAnimalArgs[1]);
                string gender = currAnimalArgs[2];

                Animal animal = null;

                switch (comand)
                {
                    case "Dog": animal = new Dog(name, age, gender); animals.Add(animal); break;
                    case "Cat": animal = new Cat(name, age, gender); animals.Add(animal); break;
                    case "Frog": animal = new Frog(name, age, gender); animals.Add(animal); break;
                    case "Kitten": animal = new Kitten(name, age); animals.Add(animal); break;
                    case "Tomcat": animal = new Tomcat(name, age); animals.Add(animal); break;

                    default: Console.WriteLine("Invalid input!");
                        break;
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
