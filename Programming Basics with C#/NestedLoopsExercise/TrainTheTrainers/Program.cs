using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfGiuri = int.Parse(Console.ReadLine());
            string lection = Console.ReadLine();

            double gradesSum = 0;
            double lectionCounter = 0;
            double lectionGrades = 0;

            while (lection != "Finish")
            {
                lectionGrades = 0;

                for (int numberOfgrades = 1; numberOfgrades <= numberOfGiuri; numberOfgrades++)
                {
                    double grades = double.Parse(Console.ReadLine());
                    gradesSum += grades;
                    lectionGrades += grades;
                }

                Console.WriteLine($"{lection} - {lectionGrades / numberOfGiuri:f2}.");
                lectionCounter++;

                lection = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {gradesSum / (numberOfGiuri * lectionCounter):f2}.");
        }
    }
}
