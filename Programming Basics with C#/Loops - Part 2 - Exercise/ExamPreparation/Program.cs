using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int limitGrades = int.Parse(Console.ReadLine());
            string problemName = Console.ReadLine();

            int counter = 0;
            double sumGrades = 0;
            int badGradecount = 0;
            string lastProblemName = "";

            while (problemName != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                sumGrades += grade;
                counter++;

                if (grade <= 4)
                {
                    badGradecount++;
                }

                if (badGradecount >= limitGrades)
                {
                    break;
                }

                lastProblemName = problemName;
                problemName = Console.ReadLine();
            }

            if (badGradecount == limitGrades)
            {
                Console.WriteLine($"You need a break, {limitGrades} poor grades.");
            }

            else
            {
                double averageScore = sumGrades / counter;

                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastProblemName}");
            }
        }
    }
}
