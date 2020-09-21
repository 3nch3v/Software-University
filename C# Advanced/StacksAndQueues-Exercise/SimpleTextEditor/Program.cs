using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> backup = new Stack<string>();

            for (int i = 0; i < operations; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string comand = cmdArgs[0];

                if (comand == "1")
                {
                    string newText = cmdArgs[1];

                    backup.Push(text.ToString());

                    text.Append(newText);
                }

                else if (comand == "2")
                {
                    backup.Push(text.ToString());

                    int count = int.Parse(cmdArgs[1]);
                    int startIndex = text.Length - count;

                    if (startIndex >= 0)
                    {
                        text.Remove(startIndex, count);
                    }
                }

                else if (comand == "3")
                {
                    int index = int.Parse(cmdArgs[1]) - 1;

                    if (index >= 0 && index < text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }
                }

                else if (comand == "4")
                {
                    text.Clear();
                    text.Append(backup.Pop());
                }
            }
        }
    }
}
