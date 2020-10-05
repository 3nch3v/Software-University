using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> prinNumber = n => Console.Write(n + " ");
            Func<string, int> parsInt = n => int.Parse(n);

            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parsInt)
                .ToArray();

            string comand = Console.ReadLine().ToLower();

            Predicate<int> numbersFilter = NumbersFilter(comand);

            List<int> numbers = CreatNumbersList(range[0], range[1], numbersFilter);

            numbers.ForEach(prinNumber);
        }

        static List<int> CreatNumbersList(int start, int end, Predicate<int> filter)
        {
            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }

        static Predicate<int> NumbersFilter(string comand)
        {
            Predicate<int> returnComand = null;

            if (comand == "odd")
            {
                returnComand = n => n % 2 != 0;
            }
            else if (comand == "even")
            {
                returnComand = n => n % 2 == 0;
            }

            return returnComand;
        }
    }
}
