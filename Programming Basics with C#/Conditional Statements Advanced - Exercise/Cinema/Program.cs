using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double places = r * c;

            switch (type)
            {
                case "Premiere": Console.WriteLine($"{places * 12:f2} leva"); break;
                case "Normal": Console.WriteLine($"{places * 7.50:f2} leva"); break;
                case "Discount": Console.WriteLine($"{places * 5:f2} leva"); break;
                default:
                    break;
            }
        }
    }
}
