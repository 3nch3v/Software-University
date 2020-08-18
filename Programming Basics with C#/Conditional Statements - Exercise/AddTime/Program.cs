using System;

namespace AddTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int newMinutes = minutes + 15;

            if (newMinutes <= 59)
            {
                Console.WriteLine($"{hours}:{newMinutes:D2}");
            }

            else if (newMinutes >= 60)
            {
                hours++;

                int mm = newMinutes % 60;

                if (hours < 23)
                {
                    Console.WriteLine($"{hours}:{mm:D2}");
                }

                else
                {
                    hours = 0;
                    Console.WriteLine($"{hours}:{mm:D2}");
                }
            }
        }
    }
}
