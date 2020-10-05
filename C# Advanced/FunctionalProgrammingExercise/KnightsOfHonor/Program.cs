using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = n => Console.WriteLine(n);

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => "Sir " + n)
                .ToList();

            names.ForEach(printName);
        }
    }
}
