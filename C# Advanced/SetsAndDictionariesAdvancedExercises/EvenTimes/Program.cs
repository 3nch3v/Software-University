using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> evenNumerCounter = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!evenNumerCounter.ContainsKey(input))
                {
                    evenNumerCounter.Add(input, 0);
                }

                evenNumerCounter[input]++;
            }

            foreach (var number in evenNumerCounter)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                }
            }

        }
    }
}
