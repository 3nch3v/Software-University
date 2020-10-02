using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {  //1. Define a Class Person

            //Person firstPerson = new Person();
            //firstPerson.Name = "Pesho";
            //firstPerson.Age = 20;

            //Person secondPerson = new Person();
            //secondPerson.Name = "Gosho";
            //secondPerson.Age = 18;

            //Person thirdPerson = new Person();
            //thirdPerson.Name = "Stamat";
            //thirdPerson.Age = 43;


            //2. Creating Constructors

            //Person firstPerson = new Person();

            //Person secondPerson = new Person(18);

            //Person thirdPerson = new Person("Pesho", 22);


            // 3. Oldest Family Member

            //Family familyMembers = new Family();

            //int personsCount = int.Parse(Console.ReadLine());

            //for (int i = 0; i < personsCount; i++)
            //{
            //    string[] personData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    string name = personData[0];
            //    int age = int.Parse(personData[1]);

            //    Person currPerson = new Person(name, age);

            //    familyMembers.AddMember(currPerson);
            //}

            //Person theOldestOne = familyMembers.GetOldestMember();
            //Console.WriteLine($"{theOldestOne.Name} {theOldestOne.Age}");


            // 4. Opinion Poll

            List<Person> personsinfo = new List<Person>();

            int personscount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personscount; i++)
            {
                string[] personinfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personinfo[0];
                int age = int.Parse(personinfo[1]);

                Person currperson = new Person(name, age);

                personsinfo.Add(currperson);
            }

            personsinfo = personsinfo
                .OrderBy(n => n.Name)
                .Where(a => a.Age > 30)
                .ToList();

            if (personsinfo.Any())
            {
                foreach (var person in personsinfo)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }
}
