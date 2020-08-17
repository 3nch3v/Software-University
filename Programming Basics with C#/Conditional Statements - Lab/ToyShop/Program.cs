using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double travelPrice = double.Parse(Console.ReadLine());
            int puzzel = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int tedybeer = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());

            int games = puzzel + dolls + tedybeer + minions + truck;
            double win = puzzel * 2.6 + dolls * 3 + tedybeer * 4.1 + minions * 8.2 + truck * 2;
            double winNetto = 0;

            if (games >= 50)
            {
                double winDiscount = win * 0.75;
                winNetto = winDiscount * 0.9;
            }

            else
            {
                winNetto = win * 0.9;
            }

            if (travelPrice <= winNetto)
            {
                Console.WriteLine($"Yes! {winNetto - travelPrice:f2} lv left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! {travelPrice - winNetto:f2} lv needed.");
            }
        }
    }
}
