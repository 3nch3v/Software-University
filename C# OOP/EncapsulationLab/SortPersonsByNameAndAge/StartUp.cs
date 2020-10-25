using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }

            Team newTeam = new Team("Best");

            foreach (var person in persons)
            {
                newTeam.AddPlayer(person);
            }

            Console.WriteLine($"First team has {newTeam.FirstTeam.Count} players.");
            Console.WriteLine($"First team has {newTeam.ReserveTeam.Count} players.");
        }
    }
}
