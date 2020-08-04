using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());

            double areaHole = (l * 100) * (w * 100);
            double areaGarderobe = (a * 100) * (a * 100);
            double banch = areaHole / 10;

            double freeSpace = areaHole - areaGarderobe - banch;
            double dancers = freeSpace / (40 + 7000);

            Console.WriteLine(Math.Floor(dancers));
        }
    }
}
