using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var sign = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                var tempResult = 0;

                if (Equals(sign, "+"))
                {
                    tempResult = firstNum + secondNum;
                }

                else if (Equals(sign, "-"))
                {
                    tempResult = firstNum - secondNum;
                }

                stack.Push(tempResult.ToString());
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
