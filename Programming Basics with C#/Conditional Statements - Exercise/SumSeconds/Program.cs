using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = a + b + c;
            int minutes = 0;
            int seconds = 0;

            if (sum % 60 == 0)
            {
                minutes = sum / 60;
                seconds = 0;

                Console.WriteLine($"{minutes}:{seconds:d2}");
            }

            else
            {
                minutes = sum / 60;
                seconds = sum % 60;

                Console.WriteLine($"{minutes}:{seconds:d2}");
            }
        }
    }
}
