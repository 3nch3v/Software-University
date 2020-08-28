using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tag = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int toPay = 0;

            for (int i = 1; i <= tag; i++)
            {
                string web = Console.ReadLine();

                switch (web)
                {
                    case "Facebook": toPay += 150; break;
                    case "Instagram": toPay += 100; break;
                    case "Reddit": toPay += 50; break;
                }

                if (toPay >= salary)
                {
                    break;
                }
            }

            if (toPay >= salary)
            {
                Console.WriteLine("You have lost your salary.");
            }

            else
            {
                Console.WriteLine($"{salary - toPay}");
            }
        }
    }
}
