using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currName = Console.ReadLine();

                names.Add(currName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
