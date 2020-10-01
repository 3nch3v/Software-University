using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int m = 1; m <= 10; m++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{m} * {i} = {m * i}");
                }
            }
        }
    }
}
