using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            Queue<string> openHoles = new Queue<string>();
            Queue<int> currValues = new Queue<int>();

            while (true)
            {
                if (stack.Count > 0)
                {
                    char isNotChar = ' ';

                    bool isAChar = char.TryParse(stack.Peek(), out isNotChar);

                    if (isAChar)
                    {
                        if (char.IsLetter(char.Parse(stack.Peek())))
                        {
                            openHoles.Enqueue(stack.Pop());
                        }
                    }

                    if (stack.Count == 0)
                    {
                        break;
                    }

                    int isNotADigit;
                    bool isDigit = int.TryParse(stack.Peek(), out isNotADigit);

                    if (isDigit)
                    {
                        if (openHoles.Count > 0)
                        {
                            int value = int.Parse(stack.Peek());

                            if (currValues.Sum() + value <= maxCapacity)
                            {
                                currValues.Enqueue(int.Parse(stack.Pop()));
                            }

                            else
                            {
                                Console.WriteLine($"{openHoles.Dequeue()} -> {string.Join(", ", currValues)}");
                                currValues.Clear();
                            }
                        }

                        else
                        {
                            stack.Pop();
                        }
                    }
                }

                else
                {
                    break;
                }
              
            }        
        }
    }
}
