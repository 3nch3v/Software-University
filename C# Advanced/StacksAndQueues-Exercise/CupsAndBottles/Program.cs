using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesInput);
            Queue<int> cups = new Queue<int>(cupsCapacity);

            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currBottle = bottles.Pop();
                int currCup = cups.Peek();

                if (currBottle >= currCup)
                {
                    wastedWater += currBottle - currCup;

                    cups.Dequeue();
                }

                else
                {
                    int[] newCapacity = cups.ToArray();
                    newCapacity[0] = currCup - currBottle;

                    cups.Clear();
                    cups = new Queue<int>(newCapacity);
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
