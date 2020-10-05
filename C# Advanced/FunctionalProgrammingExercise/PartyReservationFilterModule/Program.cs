using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>(); 

            string cmd;

            while ((cmd = Console.ReadLine()) != "Print")
            {  
                string[] tokens = cmd.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                string currFilter = GetFilter(tokens);

                if (command == "Add filter")
                {
                    filters.Add(currFilter);
                }

                else if (command == "Remove filter")
                {
                    filters.Remove(currFilter);
                }
            }

            foreach (var filter in filters)
            {
                string[] filterArg = filter.Split(";").ToArray();
                string filterType = filterArg[0];
                string filterParameter = filterArg[1];

                Predicate<string> pre = GetPredicate(filterType, filterParameter);

                guests.RemoveAll(pre);
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        static string GetFilter(string[] tokens)
        {
            string filterType = tokens[1];
            string filterParameter = tokens[2];

            return filterType + ";" + filterParameter;
        }

        static Predicate<string> GetPredicate(string filterType, string filterParameter)
        {
            switch (filterType)
            {
                case "Starts with": return g => g.StartsWith(filterParameter);
                case "Ends with": return g => g.EndsWith(filterParameter);
                case "Length": return g => g.Length == int.Parse(filterParameter);
                case "Contains": return g => g.Contains(filterParameter);
                default:
                    return null;
            }
        }
    }
}
