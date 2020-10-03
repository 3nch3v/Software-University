using System;

namespace SpecialNumbers2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int currNum = i;
                bool isSpecial = false;

                while (currNum > 0)
                {
                    int delimiter = currNum % 10;
                    currNum /= 10;

                    if (delimiter != 0 && number % delimiter == 0)
                    {
                        isSpecial = true;
                    }

                    else
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
