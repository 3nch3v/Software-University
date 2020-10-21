using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashset = new HashSet<Person>();
            SortedSet<Person> sortedset = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personArg[0];
                int age = int.Parse(personArg[1]);

                Person person = new Person(name, age);

                hashset.Add(person);
                sortedset.Add(person);
            }

            Console.WriteLine(hashset.Count);
            Console.WriteLine(sortedset.Count);
        }
    }
}
