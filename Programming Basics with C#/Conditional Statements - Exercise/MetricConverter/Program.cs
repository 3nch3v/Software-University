using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            if (input == "mm")
            {
                if (output == "cm")
                {
                    Console.WriteLine($"{number / 10:f3}");
                }

                else if (output == "m")
                {
                    Console.WriteLine($"{number / 1000:f3}");
                }
            }

            if (input == "cm")
            {
                if (output == "mm")
                {
                    Console.WriteLine($"{number * 10:f3}");
                }

                else if (output == "m")
                {
                    Console.WriteLine($"{number / 100:f3}");
                }
            }

            if (input == "m")
            {
                if (output == "cm")
                {
                    Console.WriteLine($"{number * 100:f3}");
                }

                else if (output == "mm")
                {
                    Console.WriteLine($"{number * 1000:f3}");
                }
            }
        }
    }
}
