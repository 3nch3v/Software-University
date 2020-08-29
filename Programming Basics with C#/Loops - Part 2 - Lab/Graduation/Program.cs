using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double gradeSum = 0;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    continue;
                }

                gradeSum += grade;
                counter++;
            }

            Console.WriteLine($"{name} graduated. Average grade: {gradeSum / 12:f2}");
        }
    }
}
