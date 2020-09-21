using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int totalBulletCounter = 0;
            int bulletCounter = 0;

            while (bulletsStack.Count > 0)
            {
                if (bulletCounter == gunBarrelSize)
                {
                    Console.WriteLine("Reloading!");
                    bulletCounter = 0;
                }

                if (locksQueue.Count == 0)
                {
                    break;
                }

                int currLock = locksQueue.Peek();
                int currBullet = bulletsStack.Pop();

                totalBulletCounter++;
                bulletCounter++;

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }

                else
                {
                    Console.WriteLine("Ping!");
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }

            else
            {
                int moneyEarned = intelligence - (bulletPrice * totalBulletCounter);

                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
