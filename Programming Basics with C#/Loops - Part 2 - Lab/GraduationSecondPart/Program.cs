using System;

namespace GraduationSecondPart
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double gradeSum = 0;
            int fail = 0;
            int year = 0;

            for (int i = 1; i <= 12; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 4)
                {
                    gradeSum += grade;
                    year++;
                }

                else
                {
                    fail += 1;

                    if (fail == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {i - 1} grade");

                        break;
                    }
                }
            }

            if (year == 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {gradeSum / 12:f2}");
            }
        }
    }
}
