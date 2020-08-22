using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degree = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            if (time == "Morning")
            {
                if (10 <= degree && degree <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }

                else if (18 < degree && degree <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (degree >= 25)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }

            else if (time == "Afternoon")
            {
                if (10 <= degree && degree <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (18 < degree && degree <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }

                else if (degree >= 25)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }

            else if (time == "Evening")
            {
                if (10 <= degree && degree <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (18 < degree && degree <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (degree >= 25)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {degree} degrees, get your {outfit} and {shoes}.");
        }
    }
}
