using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string comand;

            while ((comand = Console.ReadLine()) != "END")
            {
                var currArgs = comand.Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                var currComand = currArgs[0];

                switch (currComand)
                {
                    case "Pop":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("No elements");
                        }
                        ; break;

                    case "Push":
                        int[] newElements = currArgs.Skip(1)
                            .Select(int.Parse)
                                                 .ToArray();

                        for (int i = 0; i < newElements.Length; i++)
                        {
                            stack.Push(newElements[i]);
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid comand");
                    break;
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
