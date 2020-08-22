using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            double cost = 0;
            string sleep = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    sleep = "Camp";
                    cost = budget * 0.3;
                }

                else if (season == "winter")
                {
                    sleep = "Hotel";
                    cost = budget * 0.7;
                }
            }

            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    sleep = "Camp";
                    cost = budget * 0.4;
                }

                else if (season == "winter")
                {
                    sleep = "Hotel";
                    cost = budget * 0.8;
                }
            }

            else
            {
                destination = "Europe";
                sleep = "Hotel";
                cost = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{sleep} - {cost:f2}");

        }
    }
}
