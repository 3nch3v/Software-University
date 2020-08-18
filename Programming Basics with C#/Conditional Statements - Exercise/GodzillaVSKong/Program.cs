using System;

namespace GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double wear = double.Parse(Console.ReadLine());

            double deco = budget * 0.1;

            if (statist > 150)
            {
                wear = wear * 0.9;
            }

            double cost = statist * wear + deco;

            if (budget >= cost)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - cost:f2} leva left.");
            }

            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {cost - budget:f2} leva more.");
            }
        }
    }
}
