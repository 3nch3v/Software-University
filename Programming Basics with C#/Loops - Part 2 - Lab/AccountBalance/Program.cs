using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                double amount = double.Parse(Console.ReadLine());

                if (amount <= 0)
                {
                    Console.WriteLine("Invalid operation!");

                    break;
                }

                sum += amount;

                Console.WriteLine($"Increase: {amount:f2}");
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
