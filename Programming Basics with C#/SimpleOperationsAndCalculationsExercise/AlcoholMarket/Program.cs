using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double wiskyPrice = double.Parse(Console.ReadLine());
            double bier = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakia = double.Parse(Console.ReadLine());
            double wisky = double.Parse(Console.ReadLine());

            double rakiaPrice = wiskyPrice * 0.5;
            double winePrice = rakiaPrice * 0.6;
            double bierPrice = rakiaPrice * 0.2;

            double count = wiskyPrice * wisky + bierPrice * bier + winePrice * wine + rakiaPrice * rakia;

            Console.WriteLine($"{count:f2}");
        }
    }
}
