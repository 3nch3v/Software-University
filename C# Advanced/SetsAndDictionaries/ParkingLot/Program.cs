using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingData = new HashSet<string>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] currArgs = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = currArgs[0];
                string carNumber = currArgs[1];

                if (direction == "IN")
                {
                    parkingData.Add(carNumber);
                }

                else if (direction == "OUT" && parkingData.Contains(carNumber))
                {
                    parkingData.Remove(carNumber);
                }
            }

            if (parkingData.Count > 0)
            {
                foreach (var car in parkingData)
                {
                    Console.WriteLine(car);
                }
            }

            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
