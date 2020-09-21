using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pumpArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(new int[] { pumpArgs[0], pumpArgs[1], i });
            }

            int fuel = 0;

            for (int i = 0; i < n; i++)
            {
                int[] currPump = pumps.Dequeue();

                int petrol = currPump[0];
                int distanceToTheNextPump = currPump[1];

                fuel += petrol;

                if (fuel >= distanceToTheNextPump)
                {
                    fuel -= distanceToTheNextPump;
                }

                else
                {
                    i = -1;
                    fuel = 0;
                }

                pumps.Enqueue(currPump);
            }

            int start = pumps.Peek()[2];
            Console.WriteLine(start);
        }
    }
}
