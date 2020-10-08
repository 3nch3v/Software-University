using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstLootBox = new Queue<int>();

            for (int i = 0; i < firstLootInput.Length; i++)
            {
                firstLootBox.Enqueue(firstLootInput[i]);
            }

            int[] secondLootInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> secondLootBox = new Stack<int>();

            for (int i = 0; i < secondLootInput.Length; i++)
            {
                secondLootBox.Push(secondLootInput[i]);
            }

            int claimedItems = 0;

            while (true)
            {
                if (firstLootBox.Count == 0 || secondLootBox.Count == 0)
                {
                    break;
                }

                int firsValue = firstLootBox.Peek();
                int secondValue = secondLootBox.Peek();
                int currSum = firsValue + secondValue;

                if (currSum % 2 == 0)
                {
                    claimedItems += currSum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }

                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            else if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
