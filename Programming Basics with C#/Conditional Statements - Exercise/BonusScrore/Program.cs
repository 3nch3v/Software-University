using System;

namespace BonusScrore
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            double bonus = 0;

            if (number <= 100)
            {
                bonus += 5;

                if (number % 2 == 0)
                {
                    bonus += 1;
                }

                else if (number % 5 == 0)
                {
                    bonus += 2;
                }
            }

            else if (number > 100 && number <= 1000)
            {
                bonus = number * 0.2;

                if (number % 2 == 0)
                {
                    bonus += 1;
                }

                else if (number % 5 == 0)
                {
                    bonus += 2;
                }
            }

            else if (number > 1000)
            {
                bonus = number * 0.1;

                if (number % 2 == 0)
                {
                    bonus += 1;
                }

                else if (number % 5 == 0)
                {
                    bonus += 2;
                }
            }

            double score = number + bonus;

            Console.WriteLine(bonus);
            Console.WriteLine(score);
        }
    }
}
