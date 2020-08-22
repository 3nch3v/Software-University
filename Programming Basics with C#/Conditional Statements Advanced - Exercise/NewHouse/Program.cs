using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string floower = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budjet = int.Parse(Console.ReadLine());

            double cost = 0;

            switch (floower)
            {
                case "Roses":
                    if (quantity > 80)
                    {
                        cost = quantity * 5 * 0.9;
                    }

                    else
                    {
                        cost = quantity * 5;
                    }

                    break;

                case "Dahlias":
                    if (quantity > 90)
                    {
                        cost = quantity * 3.8 * 0.85;
                    }

                    else
                    {
                        cost = quantity * 3.8;
                    }

                    break;

                case "Tulips":
                    if (quantity > 80)
                    {
                        cost = quantity * 2.8 * 0.85; // - 15%
                    }

                    else
                    {
                        cost = quantity * 2.8;
                    }

                    break;

                case "Narcissus":
                    if (quantity < 120)
                    {
                        cost = quantity * 3 * 1.15;// + 15 % !!!
                    }

                    else
                    {
                        cost = quantity * 3;
                    }

                    break;

                case "Gladiolus":
                    if (quantity < 80)
                    {
                        cost = quantity * 2.5 * 1.2; // + 20 % !!!
                    }

                    else
                    {
                        cost = quantity * 2.5;
                    }

                    break;

                default:
                    break;
            }

            if (budjet >= cost)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {floower} and {budjet - cost:f2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money, you need {cost - budjet:f2} leva more.");
            }
        }
    }
}
