using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int pushElements = nsx[0];
            int popElements = nsx[1];
            int checkForNumber = nsx[2];

            int[] queueElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < pushElements; i++)
            {
                queue.Enqueue(queueElements[i]);
            }

            for (int i = 0; i < popElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(checkForNumber))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }

                else
                {
                    int minNum = queue.Min();

                    Console.WriteLine(minNum);
                }
            }
        }
    }
}
