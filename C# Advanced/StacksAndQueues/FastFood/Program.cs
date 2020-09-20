using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                int currOrder = queue.Peek();

                if (currOrder <= food)
                {
                    food -= currOrder;
                    queue.Dequeue();
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }

            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
            }
        }
    }
}
