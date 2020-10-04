using System;
using System.Collections.Generic;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checkForUpper = w => w[0] == w.ToUpper()[0];
            Action<string> printWord = w => Console.WriteLine(w);

            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checkForUpper)
                .ToList();

            words.ForEach(printWord);
        }
    }
}
