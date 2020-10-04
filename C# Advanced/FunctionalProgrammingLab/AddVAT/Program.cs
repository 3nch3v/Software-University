using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> doubleParse = n => double.Parse(n);
            Action<double> printNumbers = n => Console.WriteLine($"{n:F2}");


            List<double> prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(doubleParse)
                .Select(n => n * 1.2)
                .ToList();

            prices.ForEach(printNumbers);
        }
    }
}
