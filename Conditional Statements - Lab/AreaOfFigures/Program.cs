using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double a = double.Parse(Console.ReadLine());

            if (figure == "square")
            {
                Console.WriteLine($"{a * a:f3}");
            }

            else if (figure == "rectangle")
            {
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * b:f3}");
            }

            else if (figure == "circle")
            {
                Console.WriteLine($"{a * a * Math.PI:f3}");
            }

            else if (figure == "triangle")
            {
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * b / 2:f3}");
            }
        }
    }
}
