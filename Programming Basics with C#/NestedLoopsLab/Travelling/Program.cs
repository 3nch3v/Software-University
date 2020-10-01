using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = string.Empty;
            double money = 0;

            while (true)
            {
                destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double neededMoney = double.Parse(Console.ReadLine());
                double savedMoney = 0;

                while (neededMoney > savedMoney)
                {
                    money = double.Parse(Console.ReadLine());
                    savedMoney += money;
                }

                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
