using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string currNumber = i.ToString();

                double firstDelimiter = char.GetNumericValue(currNumber[0]);
                double secondDelimiter = char.GetNumericValue(currNumber[1]);
                double thirdDelimiter = char.GetNumericValue(currNumber[2]);
                double forthDelimiter = char.GetNumericValue(currNumber[3]);

                if (number % firstDelimiter == 0
                    && number % secondDelimiter == 0
                    && number % thirdDelimiter == 0
                    && number % forthDelimiter == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
