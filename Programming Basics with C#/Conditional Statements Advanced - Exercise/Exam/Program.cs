using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int hourArrived = int.Parse(Console.ReadLine());
            int minutesArrived = int.Parse(Console.ReadLine());

            int examTime = hour * 60 + minutes;
            int arrivedTime = hourArrived * 60 + minutesArrived;
            int addTime = examTime - arrivedTime;

            if (examTime == arrivedTime)
            {
                Console.WriteLine("On time");
            }

            if (addTime <= 30 && addTime >= 0)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{addTime} minutes before the start");
            }

            if (addTime > 30 && addTime < 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{addTime} minutes before the start");
            }

            else
            {
                int beforeMinutes = examTime - arrivedTime;
                int hh = beforeMinutes / 60;
                int mm = beforeMinutes % 60;

                Console.WriteLine("Early");
                Console.WriteLine($"{hh}:{mm:d2} hours before the start");
            }

            if (arrivedTime > examTime)
            {
                int verspaetung = arrivedTime - examTime;

                if (verspaetung < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{verspaetung} minutes after the start");
                }

                else
                {
                    int hh = verspaetung / 60;
                    int mm = verspaetung % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{hh}:{mm:d2} hours after the start");
                }
            }
        }
    }
}
