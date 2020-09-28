using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> data = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] currInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = currInfo[0];
                string country = currInfo[1];
                string city = currInfo[2];

                if (!data.ContainsKey(continent))
                {
                    data.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!data[continent].ContainsKey(country))
                {
                    data[continent].Add(country, new List<string>());
                }

                data[continent][country].Add(city);
            }

            foreach (var (continent, countryAndCities) in data)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, cities) in countryAndCities)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
