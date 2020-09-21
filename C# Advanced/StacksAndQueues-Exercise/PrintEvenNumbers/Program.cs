using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Queue<int> queue = new Queue<int>(input);

            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                int currNum = queue.Peek(); ;

                if (currNum % 2 != 0)
                {
                    queue.Dequeue();
                }

                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
