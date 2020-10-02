using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesLines = int.Parse(Console.ReadLine());

            List<Engine> enginesList = new List<Engine>();

            for (int i = 0; i < enginesLines; i++)
            { 
                string[] engineArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineArgs[0];
                string power = engineArgs[1];

                string displacement = "n/a";
                string efficiency = "n/a";

                if (engineArgs.Length > 2)
                {
                    int ignoreMe = -1;
                    bool successfullyParsed = int.TryParse(engineArgs[2], out ignoreMe);

                    if (successfullyParsed)
                    {
                        displacement = engineArgs[2];
                    }
                    else
                    {
                        efficiency = engineArgs[2];
                    }
                }

                if (engineArgs.Length > 3)
                {
                    efficiency = engineArgs[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency );
                enginesList.Add(engine);
            }

            List<Car> carsList = new List<Car>();

            int carLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < carLines; i++)
            { 
                string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];

                Engine engine = null;
                string engineModel = carArgs[1];

                foreach (var currEngine in enginesList)
                {
                    if (currEngine.Model == engineModel)
                    {
                        engine = currEngine;
                        break;
                    }
                }

                string weight = "n/a";
                string color = "n/a";

                if (carArgs.Length > 2)
                {
                    int ignoreMe = -1;
                    bool successfullyParsed = int.TryParse(carArgs[2], out ignoreMe);

                    if (successfullyParsed)
                    {
                        weight = carArgs[2];
                    }
                    else
                    {
                        color = carArgs[2];
                    }
                   
                }

                if (carArgs.Length > 3)
                {
                    color = carArgs[3];
                }

                Car car = new Car(model, engine, weight, color);
                carsList.Add(car);
            }

            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
