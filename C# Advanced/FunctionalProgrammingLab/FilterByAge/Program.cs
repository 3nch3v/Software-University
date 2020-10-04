using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] persons = FullPersonsArray(n);

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> isValidCase = GetPerson(condition, age);
            Action<Person> printPerson = PrintResult(format);

            foreach (var currPerson in persons)
            {
                if (isValidCase(currPerson))
                {
                    printPerson(currPerson);
                }
            }
        }

        static Person[] FullPersonsArray(int n)
        {
            Person[] persons = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int personAge = int.Parse(input[1]);

                persons[i] = new Person()
                {
                    Name = name,
                    Age = personAge
                };
            }

            return persons;
        }

        static Action<Person> PrintResult(string format)
        {
            Action<Person> printer = null;

            if (format == "name")
            {
                printer = p => Console.WriteLine(p.Name);
            }

            else if (format == "age")
            {
                printer = p => Console.WriteLine(p.Age);
            }

            else if (format == "name age")
            {
                printer = p => Console.WriteLine($"{p.Name} - {p.Age}");
            }

            return printer;
        }

        static Func<Person, bool> GetPerson(string condition, int age)
        {
            Func<Person, bool> func = null;

            if (condition == "younger")
            {
                func = p => p.Age < age;
             
            }

            else if (condition == "older")
            {
                func=  p => p.Age >= age;
          
            }

            return func;
        }
    }
}
