using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parseNumber = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parseNumber)
                .OrderBy(n => n)
                .Take(1)
                .ToArray();

            Console.WriteLine(numbers[0]);
        }
    }
}
