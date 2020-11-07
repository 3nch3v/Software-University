using System;
using System.Collections.Generic;
using System.Text;
using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson justName = citizen;
                Console.WriteLine(justName.GetName());

                IResident residentName = citizen;
                Console.WriteLine(residentName.GetName());
            }
        }
    }
}
