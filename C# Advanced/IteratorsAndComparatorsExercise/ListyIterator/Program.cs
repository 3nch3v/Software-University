using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            ListyIterator<string> list = null;

            string comand;

            while ((comand = Console.ReadLine()) != "END")
            {
                try
                {
                    var input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string currComand = input[0];

                    switch (currComand)
                    {
                        case "Create":
                            var currAgrs = input.Skip(1).ToList();
                            list = new ListyIterator<string>(currAgrs);
                            break;
                        case "Move":
                            Console.WriteLine(list.Move());
                            break;
                        case "HasNext": Console.WriteLine(list.HasNext());
                            break;
                        case "Print":list.Print();
                            break;
                        case "PrintAll":
                            foreach (var element in list)
                            {
                                Console.Write($"{element} ");
                            }
                            Console.WriteLine();
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
