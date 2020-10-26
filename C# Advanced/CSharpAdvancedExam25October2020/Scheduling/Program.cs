using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            Queue<int> threads = new Queue<int>(
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            int value = int.Parse(Console.ReadLine());

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int tasksValue = tasks.Peek();
                int threadsValue = threads.Peek();

                if (tasksValue == value)
                {
                    break;
                }

                if (threadsValue >= tasksValue)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }

                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {value}");
            Console.WriteLine($"{string.Join(" ", threads)}");
        }
    }
}
