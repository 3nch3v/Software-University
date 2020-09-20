using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
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

            int[] stackElementsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            if (pushElements <= stackElementsInput.Length)
            {
                for (int i = 0; i < pushElements; i++)
                {
                    stack.Push(stackElementsInput[i]);
                }
            }

            if (stack.Count >= popElements)
            {
                for (int i = 0; i < popElements; i++)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(checkForNumber))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }

                else
                {
                    int minNumber = stack.Pop();

                    for (int i = 0; i < stack.Count; i++)
                    {
                        int currNum = stack.Pop();

                        if (currNum < minNumber)
                        {
                            minNumber = currNum;
                        }
                    }

                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
