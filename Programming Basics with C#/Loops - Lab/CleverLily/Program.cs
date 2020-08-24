using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int years = int.Parse(Console.ReadLine());
            double washer = double.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());

            double savedMoney = 0;
            double save = 0; // 150
            int toys = 0;  // 6 * 5
            double brother = 0; // - 5

            for (int i = 1; i <= years; i++)
            {
                if (i % 2 == 0)
                {
                    brother += 1;
                    savedMoney = savedMoney + 10;
                    save += savedMoney;
                }

                else
                {
                    toys += 1;
                }
            }

            double netto = save + (toys * toysPrice) - brother;

            if (netto >= washer)
            {
                Console.WriteLine($"Yes! {netto - washer:f2}");
            }

            else
            {
                Console.WriteLine($"No! {washer - netto:f2}");
            }
        }
    }
}
