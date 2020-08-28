using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int max = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                sum += number;

                if (max < number)
                {
                    max = number;
                }
            }

            int sumMinusMax = sum - max;

            if (max == sumMinusMax)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }

            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumMinusMax - max)}");
            }
        }
    }
}
