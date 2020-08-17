using System;

namespace ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double note = double.Parse(Console.ReadLine());

            if (note >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
