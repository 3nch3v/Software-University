using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;
            int nn = 0;
            int magicCounter = 0;

            for (int i = start; i <= end; i++)
            {
                for (int n = start; n <= end; n++)
                {
                    nn = n;
                    sum = i + n;
                    counter++;

                    if (i + n == magicNumber)
                    {
                        magicCounter++;
                        Console.WriteLine($"Combination N:{counter} ({i} + {n} = {magicNumber})");
                        break;
                    }
                }

                if (i + nn == magicNumber)
                {
                    break;
                }
            }

            if (magicCounter <= 0)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
