using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(quantity * 0.5); break;
                    case "water": Console.WriteLine(quantity * 0.8); break;
                    case "beer": Console.WriteLine(quantity * 1.2); break;
                    case "sweets": Console.WriteLine(quantity * 1.45); break;
                    case "peanuts": Console.WriteLine(quantity * 1.6); break;
                    default:
                        break;
                }
            }

            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(quantity * 0.4); break;
                    case "water": Console.WriteLine(quantity * 0.7); break;
                    case "beer": Console.WriteLine(quantity * 1.15); break;
                    case "sweets": Console.WriteLine(quantity * 1.30); break;
                    case "peanuts": Console.WriteLine(quantity * 1.50); break;
                    default:
                        break;
                }
            }

            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee": Console.WriteLine(quantity * 0.45); break;
                    case "water": Console.WriteLine(quantity * 0.7); break;
                    case "beer": Console.WriteLine(quantity * 1.1); break;
                    case "sweets": Console.WriteLine(quantity * 1.35); break;
                    case "peanuts": Console.WriteLine(quantity * 1.55); break;
                    default:
                        break;
                }
            }
        }
    }
}
