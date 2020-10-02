using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {  
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                carList.Add(car);
            }

            string comand;

            while ((comand = Console.ReadLine()) != "End")
            { 
                string[] comandArgs = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = comandArgs[1];
                double amountOfKm = double.Parse(comandArgs[2]);

                foreach (var car in carList)
                {
                    if (car.Model == carModel)
                    {
                        car.Move(amountOfKm);
                    }
                }
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
