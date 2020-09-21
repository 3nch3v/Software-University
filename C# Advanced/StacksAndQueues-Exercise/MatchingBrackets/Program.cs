using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Equals(input[i], '('))
                {
                    stack.Push(i);
                }

                if (Equals(input[i], ')'))
                {
                    int startIndex = stack.Pop();
                    int endIndex = i - startIndex + 1;
                    string subString = input.Substring(startIndex, endIndex);

                    Console.WriteLine(subString);
                }
            }
        }
    }
}
