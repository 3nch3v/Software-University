using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int room = int.Parse(Console.ReadLine());

            for (int f = floor; f >= 1; f--)
            {
                Console.WriteLine();

                for (int r = 0; r < room; r++)
                {
                    if (f == floor)
                    {
                        Console.Write($"L{f}{r} ");
                    }
                    else if (f % 2 == 0)
                    {
                        Console.Write($"O{f}{r} ");
                    }
                    else
                    {
                        Console.Write($"A{f}{r} ");
                    }
                }
            }
        }
    }
}
