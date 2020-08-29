using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = (Console.ReadLine());

            int sum = 0;

            while (comand != "Stop")
            {
                int numbers = int.Parse(comand);
                sum += numbers;
                comand = (Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
