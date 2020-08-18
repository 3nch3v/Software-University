using System;

namespace SwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double seconds = double.Parse(Console.ReadLine());

            double timing = distance * seconds;
            double addTime = distance / 15;
            double addTime1 = Math.Floor(addTime) * 12.5;
            double time = timing + addTime1;

            if (record > time)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }

            else
            {
                Console.WriteLine($"No, he failed! He was {time - record:f2} seconds slower.");
            }
        }
    }
}
