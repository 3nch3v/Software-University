using System;
using System.Collections;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> parenthesis = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];

                if (parenthesis.Count > 0)
                {
                    if ((parenthesis.Peek() == '{' && currChar == '}')
                        || parenthesis.Peek() == '[' && currChar == ']'
                        || parenthesis.Peek() == '(' && currChar == ')')
                    {
                        parenthesis.Pop();
                    }

                    else
                    {
                        parenthesis.Push(currChar);
                    }
                }

                else
                {
                    parenthesis.Push(currChar);
                }
            }

            if (parenthesis.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
