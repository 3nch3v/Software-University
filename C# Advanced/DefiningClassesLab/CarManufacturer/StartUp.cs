using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresData = new List<Tire[]>();

            string tiresInfo;

            while ((tiresInfo = Console.ReadLine()) != "No more tires")
            {
                string[] currInfo = tiresInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] currTires = new Tire[]
                {
                    new Tire(int.Parse(currInfo[0]), double.Parse(currInfo[1])),
                    new Tire(int.Parse(currInfo[2]), double.Parse(currInfo[3])),
                    new Tire(int.Parse(currInfo[4]), double.Parse(currInfo[5])),
                    new Tire(int.Parse(currInfo[6]), double.Parse(currInfo[7]))
                };

                tiresData.Add(currTires);
            }


            List<Engine> enginesData = new List<Engine>();

            string enginesInfo;

            while ((enginesInfo = Console.ReadLine()) != "Engines done")
            {
                string[] currArgs = enginesInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(currArgs[0]), double.Parse(currArgs[1]));

                enginesData.Add(engine);
            }

            List<Car> cars = new List<Car>();

            string carsInfo;

            while ((carsInfo = Console.ReadLine()) != "Show special")
            {
                string[] currArr = carsInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var make = currArr[0];
                var model = currArr[1];
                var year = int.Parse(currArr[2]);
                var fuelQuantity = double.Parse(currArr[3]);
                var fuelCapacity = double.Parse(currArr[4]);
                var engineIndex = int.Parse(currArr[5]);
                var tireIndex = int.Parse(currArr[6]);

                if ((engineIndex >= 0 && engineIndex < enginesData.Count)
                    && (tireIndex >= 0 && tireIndex < tiresData.Count))
                {
                    Car car = new Car(make, model, year, fuelQuantity, fuelCapacity,
                                      enginesData[engineIndex], tiresData[tireIndex]);

                    cars.Add(car);
                }
            }

            cars = cars.Where(x => x.Year >= 2017
                                   && x.Engine.HorsePower > 330
                                   && x.Tires.Sum(y => y.Pressure) >= 9
                                   && x.Tires.Sum(y => y.Pressure) <= 10)
                       .ToList();

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
