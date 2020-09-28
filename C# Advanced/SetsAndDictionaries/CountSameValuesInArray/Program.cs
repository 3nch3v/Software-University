using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counter = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                double currNum = input[i];

                if (!counter.ContainsKey(currNum))
                {
                    counter.Add(currNum, 0);
                }

                counter[currNum] += 1;
            }

            foreach (var KVP in counter)
            {
                Console.WriteLine($"{KVP.Key} - {KVP.Value} times");
            }
        }
    }
}
