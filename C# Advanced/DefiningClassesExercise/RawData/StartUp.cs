using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currAgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = currAgs[0];

                int engineSpeed = int.Parse(currAgs[1]);
                int enginePower = int.Parse(currAgs[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(currAgs[3]);
                string cargoType = currAgs[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(currAgs[5]);
                int tire1Age = int.Parse(currAgs[6]);

                Tire tireOne = new Tire(tire1Pressure, tire1Age);

                double tire2Pressure = double.Parse(currAgs[7]);
                int tire2Age = int.Parse(currAgs[8]);

                Tire tireTwo = new Tire(tire2Pressure, tire2Age);

                double tire3Pressure = double.Parse(currAgs[9]);
                int tire3Age = int.Parse(currAgs[10]);

                Tire tireThree = new Tire(tire3Pressure, tire3Age);

                double tire4Pressure = double.Parse(currAgs[11]);
                int tire4Age = int.Parse(currAgs[12]);

                Tire tireFour = new Tire(tire4Pressure, tire4Age);

                Tire[] tires = new Tire[] { tireOne , tireTwo, tireThree, tireFour };

                Car car = new Car(model, engine, cargo, tires);

                carsList.Add(car);
            }

            string comand = Console.ReadLine();

            PrintOutput(comand, carsList);          
        }

        static void PrintOutput(string comand, List<Car> carsList)
        {
            if (comand == "fragile")
            { 
                carsList = carsList
                    .Where(c => c.Cargo.CargoType == "fragile")
                    .ToList();

                foreach (var car in carsList)
                {
                    Tire[] tires = car.Tires;

                    foreach (var tire in tires)
                    {
                        if (tire.TirePressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }

            else if (comand == "flamable")
            {
                carsList = carsList
                    .Where(c => c.Cargo.CargoType == "flamable")
                    .Where(e => e.Engine.EnginePower > 250)
                    .ToList();

                foreach (var car in carsList)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
