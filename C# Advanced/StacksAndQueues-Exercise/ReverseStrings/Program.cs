using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>(input);

            foreach (var currChar in stack)
            {
                Console.Write(currChar);
            }

            Console.WriteLine();
        }
    }
}
