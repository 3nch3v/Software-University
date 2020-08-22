using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();

            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int weeks = 48;

            double playSofia = (weeks - h) * 1.0 * 3 / 4;
            double playH = h * 1.0;
            double playP = p * 1.0 * 2 / 3;

            double allPlays = playH + playP + playSofia;

            if (year == "leap")
            {
                allPlays *= 1.15;
                Console.WriteLine(Math.Floor(allPlays));
            }

            else
            {
                Console.WriteLine(Math.Floor(allPlays));
            }
        }
    }
}
