using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());

            int anotherDogs = int.Parse(Console.ReadLine());

            double costs = dogs * 2.50 + anotherDogs * 4;

            Console.WriteLine($"{costs:F2}lv.");
        }
    }
}
