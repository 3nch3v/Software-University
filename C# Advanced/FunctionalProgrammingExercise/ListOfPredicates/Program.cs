using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> validNumbers = NumbersFinder(end, dividers);
            Console.WriteLine(string.Join(" ", validNumbers));
        }

        static List<int> NumbersFinder(int end, int[] dividers)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                bool isValid = false;

                for (int j = 0; j < dividers.Length; j++)
                {
                    int currDivider = dividers[j];
                    Predicate<int> pre = n => n % currDivider == 0;

                    if (pre(i))
                    {
                        isValid = true;
                    }

                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }
    }
}
