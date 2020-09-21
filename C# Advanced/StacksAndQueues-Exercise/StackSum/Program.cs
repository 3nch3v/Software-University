using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            string comand;

            while ((comand = Console.ReadLine().ToLower()) != "end")
            {
                string[] comandArgs = comand.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currCmd = comandArgs[0];

                if (Equals(currCmd, "add"))
                {
                    int firstNumber = int.Parse(comandArgs[1]);
                    int secondNumber = int.Parse(comandArgs[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }

                else if (Equals(currCmd, "remove"))
                {
                    int removeElements = int.Parse(comandArgs[1]);

                    if (stack.Count >= removeElements)
                    {
                        for (int i = 0; i < removeElements; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
