using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstGroupOfNumbers = new HashSet<int>();
            HashSet<int> secondGroupOfNumbers = new HashSet<int>();

            int[] length = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstGroupLength = length[0];

            for (int i = 0; i < firstGroupLength; i++)
            {
                int input = int.Parse(Console.ReadLine());

                firstGroupOfNumbers.Add(input);
            }

            int secondGroupLength = length[1];

            for (int i = 0; i < secondGroupLength; i++)
            {
                int input = int.Parse(Console.ReadLine());

                secondGroupOfNumbers.Add(input);
            }

            foreach (var number in firstGroupOfNumbers)
            {
                if (secondGroupOfNumbers.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
