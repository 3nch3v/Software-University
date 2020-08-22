using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fischer = int.Parse(Console.ReadLine());

            double price = 0;

            if (season == "Spring")
            {
                price = 3000;

                if (fischer <= 6)
                {
                    price *= 0.9;

                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }

                else if (fischer >= 7 && fischer <= 11)
                {
                    price *= 0.85;

                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }

                else if (fischer > 12)
                {
                    price *= 0.75;

                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }
            }

            if (season == "Summer")
            {
                price = 4200;

                if (fischer <= 6)
                {
                    price *= 0.9;
                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }

                else if (fischer >= 7 && fischer <= 11)
                {
                    price *= 0.85;
                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }
                else if (fischer > 12)
                {
                    price *= 0.75;
                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }
            }

            if (season == "Autumn")
            {
                price = 4200;

                if (fischer <= 6)
                {
                    price *= 0.9;
                }

                else if (fischer >= 7 && fischer <= 11)
                {
                    price *= 0.85;
                }

                else if (fischer > 12)
                {
                    price *= 0.75;
                }
            }

            if (season == "Winter")
            {
                price = 2600;

                if (fischer <= 6)
                {
                    price *= 0.9;

                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }

                else if (fischer >= 7 && fischer <= 11)
                {
                    price *= 0.85;

                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }

                else if (fischer > 12)
                {
                    price *= 0.75;

                    if (fischer % 2 == 0)
                    {
                        price *= 0.95;
                    }
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
            }
        }
    }
}
