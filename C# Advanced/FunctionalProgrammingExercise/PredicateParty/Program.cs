using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comand;

            while ((comand = Console.ReadLine()) != "Party!")
            {
                string[] currArgs = comand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string pre = currArgs[1];
                string content = currArgs[2];

                Predicate<string> predicate = GetPredicate(pre, content);

                if (comand.Contains("Remove"))
                {
                    people.RemoveAll(predicate);
                }

                else if (comand.Contains("Double"))
                {
                    List<string> matches = people.FindAll(predicate);

                    if (matches.Count > 0)
                    {
                        var index = people.FindIndex(predicate);
                        people.InsertRange(index, matches);
                    }
                }
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }

            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string pre, string arg)
        {
            if (pre == "StartsWith")
            {
                return n => n.StartsWith(arg);
            }

            else if (pre == "EndsWith")
            {
                return n => n.EndsWith(arg);
            }

            else if (pre == "Length")
            {
                return n => n.Length == int.Parse(arg);
            }

            throw new ArgumentException("Invalid command type");
        }
    }
}
