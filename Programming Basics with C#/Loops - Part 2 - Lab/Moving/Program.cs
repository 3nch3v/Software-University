using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int area = w * l * h;
            int counter = 0;

            while (area >= counter)
            {
                string comand = Console.ReadLine();

                if (comand == "Done")
                {
                    break;
                }

                int packages = int.Parse(comand);
                counter += packages;

            }

            if (area < counter)
            {
                Console.WriteLine($"No more free space! You need {counter - area} Cubic meters more.");
            }

            else
            {
                Console.WriteLine($"{area - counter} Cubic meters left.");
            }
        }
    }
}
