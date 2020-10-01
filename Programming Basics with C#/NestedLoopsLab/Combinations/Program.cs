using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int X1 = 0; X1 <= number; X1++)
            {
                for (int X2 = 0; X2 <= number; X2++)
                {
                    for (int X3 = 0; X3 <= number; X3++)
                    {
                        int sum = X1 + X2 + X3;
                        if (sum == number)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
