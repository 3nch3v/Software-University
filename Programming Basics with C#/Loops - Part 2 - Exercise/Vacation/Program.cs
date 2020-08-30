using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availableAmount = double.Parse(Console.ReadLine());

            double savedMoney = availableAmount;
            int spendDays = 0;
            int daysCounter = 0;

            while (moneyNeeded > savedMoney)
            {
                string comand = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                daysCounter++;

                if (comand == "save")
                {
                    savedMoney += money;
                    spendDays = 0;
                }

                else if (comand == "spend")
                {
                    spendDays++;

                    if (spendDays >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(daysCounter);

                        break;
                    }

                    savedMoney -= money;

                    if (savedMoney < 0)
                    {
                        savedMoney = 0;
                    }
                }
            }

            if (moneyNeeded <= savedMoney)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
