using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] males = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> malesArgs = new Stack<int>();

            int[] females = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> femalesArgs = new Queue<int>();

            int maxCount = Math.Max(males.Length, females.Length);

            for (int i = 0; i < maxCount; i++)
            {
                if (males.Length > i)
                {
                    malesArgs.Push(males[i]);
                }

                if (females.Length > i)
                {
                    femalesArgs.Enqueue(females[i]);
                }
            }

            int matchesCount = 0;

            while (true)
            {
                if (malesArgs.Count == 0 || femalesArgs.Count == 0)
                {
                    break;
                }

                int maleValue = malesArgs.Peek();
                int femaleValue = femalesArgs.Peek();

                if (maleValue <= 0 || femaleValue <= 0)
                {
                    if (maleValue <= 0)
                    {
                        malesArgs.Pop();
                    }

                    if (femaleValue <= 0)
                    {
                        femalesArgs.Dequeue();
                    }
                }

                else if (maleValue % 25 == 0 || femaleValue % 25 == 0)
                {
                    if (maleValue % 25 == 0)
                    {
                        malesArgs.Pop();
                        malesArgs.Pop();
                    }

                    if (femaleValue % 25 == 0)
                    {
                        femalesArgs.Dequeue();
                        femalesArgs.Dequeue();
                    }
                }

                else
                {
                    if (maleValue == femaleValue)
                    {
                        matchesCount++;

                        malesArgs.Pop();
                        femalesArgs.Dequeue();
                    }

                    else
                    {
                        femalesArgs.Dequeue();
                        malesArgs.Push(malesArgs.Pop() - 2);
                    }
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (malesArgs.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", malesArgs)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (femalesArgs.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", femalesArgs)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
