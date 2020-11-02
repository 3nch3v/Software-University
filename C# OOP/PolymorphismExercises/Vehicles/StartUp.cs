using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
    
            string[] truckInfo = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                string comand = tokens[0];
                string vehicleType = tokens[1];
                double value = double.Parse(tokens[2]);

                switch (comand)
                {
                    case "Drive":

                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(value));
                        }

                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(value)); 
                        }

                        else
                        {
                            Console.WriteLine(truck.Drive(value));
                        }
                        break;

                    case "DriveEmpty":
                        Console.WriteLine(bus.DriveEmpty(value));
                        break;

                    case "Refuel":

                        try
                        {
                            if (vehicleType == "Car")
                            {
                                car.Refuel(value);
                            }

                            else if (vehicleType == "Bus")
                            {
                                bus.Refuel(value);
                            }

                            else
                            {
                                truck.Refuel(value);
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
