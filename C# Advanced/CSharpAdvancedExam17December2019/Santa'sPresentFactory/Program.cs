using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] magicLevel = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> magics = new Queue<int>();
            Stack<int> materials = new Stack<int>();

            int maxCount = Math.Max(materialsInput.Length, magicLevel.Length);

            for (int i = 0; i < maxCount; i++)
            {
                if (i < materialsInput.Length)
                {
                    materials.Push(materialsInput[i]);
                }

                if (i < magicLevel.Length)
                {
                    magics.Enqueue(magicLevel[i]);
                }
            }

            Dictionary<string, int[]> presents = new Dictionary<string, int[]>()
            {
                {"Doll", new int[] {150, 0} },
                {"Wooden train", new int[] {250, 0} },
                {"Teddy bear", new int[] {300, 0} },
                {"Bicycle", new int[] {400, 0} },
            };

            while (true)
            {
                if (materials.Count == 0 || magics.Count == 0)
                {
                    break;
                }

                int material = materials.Peek();
                int magic = magics.Peek();

                int currMagic = material * magic;

                if (currMagic > 0)
                {
                    bool isPresentMached = false;

                    foreach (var present in presents)
                    {
                        if (present.Value[0] == currMagic)
                        {
                            present.Value[1]++;
                            isPresentMached = true;
                            materials.Pop();
                            magics.Dequeue();

                            break;
                        }
                    }

                    if(!isPresentMached)
                    {
                        magics.Dequeue();
                        materials.Push(materials.Pop() + 15);
                    }
                }
             
                else if (currMagic < 0)
                {
                    currMagic = material + magic;

                    materials.Pop();
                    magics.Dequeue();

                    materials.Push(currMagic);
                }

                else if (material == 0 || magic == 0)
                {
                    if (material == 0)
                    {
                        materials.Pop();
                    }

                    if (magic == 0)
                    {
                        magics.Dequeue();
                    }
                }
            }


            if ((presents["Doll"][1] > 0 && presents["Wooden train"][1] > 0) || (presents["Teddy bear"][1] > 0 && presents["Bicycle"][1] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }

            else
            {
                Console.WriteLine("No presents this Christmas!");
            }


            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magics.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magics)}");
            }  


            presents = presents.Where(v => v.Value[1] > 0).OrderBy(n => n.Key).ToDictionary(n => n.Key, v => v.Value);

            foreach (var present in presents)
            {
                Console.WriteLine($"{present.Key}: {present.Value[1]}");
            }
        }
    }
}
