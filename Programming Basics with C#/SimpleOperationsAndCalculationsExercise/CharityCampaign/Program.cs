using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int chefs = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffels = int.Parse(Console.ReadLine());
            int panecakes = int.Parse(Console.ReadLine());

            double cakePrice = 45;
            double waffelPrice = 5.80;
            double panecakePrice = 3.20;

            double win = days * chefs * ((cakePrice * cakes) + (waffelPrice * waffels) + (panecakePrice * panecakes));
            double nettoWin = win - (win / 8);

            Console.WriteLine($"{nettoWin:F2}");
        }
    }
}
