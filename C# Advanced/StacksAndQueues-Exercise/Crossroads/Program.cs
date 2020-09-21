using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int greenLight = greenLightDuration;

            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;
            
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    while (greenLight > 0 && cars.Count > 0)
                    {
                        string currCar = cars.Peek();

                        if (greenLight >= currCar.Length)
                        {
                            totalCarsPassed++;
                            greenLight -= currCar.Length;
                            cars.Dequeue();
                        }

                        else if ((greenLight + freeWindow) >= currCar.Length)
                        {
                            totalCarsPassed++;
                            greenLight = 0;
                            cars.Dequeue();
                        }

                        else if ((greenLight + freeWindow) < currCar.Length)
                        {
                            int index = greenLight + freeWindow;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currCar} was hit at {currCar[index]}.");

                            return;
                        }
                    }
                }

                else
                {
                    cars.Enqueue(input);
                }

                greenLight = greenLightDuration;
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
