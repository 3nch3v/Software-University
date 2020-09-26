using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];

                if (!counter.ContainsKey(currChar))
                {
                    counter.Add(currChar, 0);
                }

                counter[currChar]++;
            }

            foreach (var currChar in counter)
            {
                Console.WriteLine($"{currChar.Key}: {currChar.Value} time/s");
            }
        }
    }
}
