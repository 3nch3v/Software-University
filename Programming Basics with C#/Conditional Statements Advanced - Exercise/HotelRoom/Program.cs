using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            int night = int.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceApartment = 0;
            double constStudio = 0;
            double constApartment = 0;

            if (season == "May" || season == "October")
            {
                priceStudio = 50;
                priceApartment = 65;

                constStudio = night * priceStudio;
                constApartment = night * priceApartment;

                if (night > 7 && night <= 14)
                {
                    constStudio = night * priceStudio * 0.95;
                }

                else if (night > 14)
                {
                    constStudio = night * priceStudio * 0.7;
                    constApartment = night * priceApartment * 0.9;
                }
            }

            else if (season == "June" || season == "September")
            {
                priceStudio = 75.2;
                priceApartment = 68.7;
                constStudio = night * priceStudio;
                constApartment = night * priceApartment;

                if (night > 14)
                {
                    constStudio = night * priceStudio * 0.8;
                    constApartment = night * priceApartment * 0.9;
                }
            }

            else if (season == "July" || season == "August")
            {
                priceStudio = 76;
                priceApartment = 77;
                constStudio = night * priceStudio;
                constApartment = night * priceApartment;

                if (night > 14)
                {
                    constApartment = night * priceApartment * 0.9;
                }
            }

            Console.WriteLine($"Apartment: {constApartment:f2} lv.");
            Console.WriteLine($"Studio: {constStudio:f2} lv.");
        }
    }
}
