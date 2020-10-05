using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parseInt = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parseInt)
                .ToArray();

            string cmd;

            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd != "print" && cmd != "end")
                {
                    Func<int, int> operation = GetOperation(cmd);

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = operation(numbers[i]);
                    }
                }

                else if (cmd == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }

        static Func<int, int> GetOperation(string comand)
        {
            switch (comand)
            {
                case "add": return n => n + 1;
                case "multiply": return n => n * 2;
                case "subtract": return n => n - 1;
                default:
                    return null;
            }
        }
    }
}
