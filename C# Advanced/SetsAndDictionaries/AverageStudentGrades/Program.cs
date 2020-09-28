using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsRecords = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currStudent = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentsRecords.ContainsKey(currStudent))
                {
                    studentsRecords.Add(currStudent, new List<decimal>());
                }

                studentsRecords[currStudent].Add(grade);
            }

            foreach (var KVP in studentsRecords)
            {  
                Console.Write($"{KVP.Key} -> ");

                foreach (var grade in KVP.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {KVP.Value.Average():f2})");
            }
        }
    }
}
