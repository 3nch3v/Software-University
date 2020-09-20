using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(input);

            int capacity = int.Parse(Console.ReadLine());
            int rackCounter = 1;
            int value = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int temp = value + clothes.Peek();

                if (capacity >= temp)
                {
                    value += clothes.Pop();
                }

                else
                {
                    rackCounter++;
                    i--;
                    value = 0;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
