using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string comand;

            while ((comand = Console.ReadLine()) != "END")
            {
                var currPersonArgs = comand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = currPersonArgs[0];
                int age = int.Parse(currPersonArgs[1]);
                string town = currPersonArgs[2];

                Person newPerson = new Person(name, age, town);
                persons.Add(newPerson);
            }

            int position = int.Parse(Console.ReadLine()) - 1;

            Person comparedPerson = persons[position];
            int matches = 0;

            foreach (Person person in persons)
            {
                if (person.CompareTo(comparedPerson) == 0)
                {
                    matches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {persons.Count - matches} {persons.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
