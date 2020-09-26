using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> periodicTable = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in input)
                {
                    periodicTable.Add(element);
                }
            }

            periodicTable = periodicTable.OrderBy(n => n).ToHashSet();

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
