using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int l = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double area = (l * w * h) * 0.001;
            double nettoArea = area * (1 - (percent * 0.01));

            Console.WriteLine($"{nettoArea:f3}");
        }
    }
}
