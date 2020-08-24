using System;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int score = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (letter == 'a')
                {
                    score += 1;
                }

                if (letter == 'e')
                {
                    score += 2;
                }

                if (letter == 'i')
                {
                    score += 3;
                }

                if (letter == 'o')
                {
                    score += 4;
                }

                if (letter == 'u')
                {
                    score += 5;
                }
            }

            Console.WriteLine(score);
        }
    }
}
