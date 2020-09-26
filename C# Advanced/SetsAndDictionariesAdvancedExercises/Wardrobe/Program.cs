using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrope = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            { 
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string inputClothes = input[1];

                if (!wardrope.ContainsKey(color))
                {
                    wardrope.Add(color, new Dictionary<string, int>());
                }
            
                string[] clothes = inputClothes.Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currItem = clothes[j];

                    if (!wardrope[color].ContainsKey(currItem))
                    {
                        wardrope[color].Add(currItem, 0);
                    }

                    wardrope[color][currItem]++;
                }          
            }

            string[] lookFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorNeeded = lookFor[0];
            string clothingNeeded = lookFor[1];

            foreach (var (currColor, currItems) in wardrope)
            {
                if (currColor == colorNeeded && currItems.ContainsKey(clothingNeeded))
                {
                    Console.WriteLine($"{currColor} clothes:");

                    foreach (var (item, count) in currItems)
                    {
                        if (item == clothingNeeded)
                        {
                            Console.WriteLine($"* {item} - {count} (found!)");
                        }

                        else
                        {
                            Console.WriteLine($"* {item} - {count}");
                        }
                    }
                }

                else
                {
                    Console.WriteLine($"{currColor} clothes:");

                    foreach (var (item, count) in currItems)
                    {
                        Console.WriteLine($"* {item} - {count}");
                    }
                }
            }
        }
    }
}
