using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<IBuyer> data = new List<IBuyer>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] currPerson = Console.ReadLine().Split();

                if (currPerson.Length == 4)
                {
                    string name = currPerson[0];
                    int age = int.Parse(currPerson[1]);
                    string id = currPerson[2];
                    string birthdate = currPerson[3];

                    data.Add(new Citizen(name, age, id, birthdate));
                }

                else if (currPerson.Length == 3)
                {
                    string name = currPerson[0];
                    int age = int.Parse(currPerson[1]);
                    string group = currPerson[2];

                    data.Add(new Rebel(name, age, group));
                }
            }

            string comand;

            while ((comand = Console.ReadLine()) != "End")
            {
                if (data.Any(p => p.Name == comand))
                {
                   data.FirstOrDefault(p => p.Name == comand).BuyFood();
                }
            }

            int food = 0;

            foreach (var person in data)
            {
                food += person.Food;
            }

            Console.WriteLine(food);
        }
    }
}
