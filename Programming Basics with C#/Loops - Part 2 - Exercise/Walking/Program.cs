using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            int stepsCounter = 0;

            while (comand != "Going home")
            {
                int steps = int.Parse(comand);

                stepsCounter += steps;

                if (stepsCounter >= 10000)
                {
                    break;
                }

                comand = Console.ReadLine();
            }

            if (comand == "Going home")
            {
                int steps = int.Parse(Console.ReadLine());
                stepsCounter += steps;

                if (stepsCounter >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                }

                else
                {
                    Console.WriteLine($"{10000 - stepsCounter} more steps to reach goal.");
                }
            }

            else
            {
                Console.WriteLine("Goal reached! Good job!");
            }
        }
    }
}
