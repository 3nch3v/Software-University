using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bombCasingsArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>();
            Stack<int> bombCasings = new Stack<int>();

            int maxCount = Math.Max(bombEffectsArgs.Length, bombCasingsArgs.Length);

            for (int i = 0; i < maxCount; i++)
            {
                if (bombCasingsArgs.Length > i)
                {
                    bombCasings.Push(bombCasingsArgs[i]);
                }

                if (bombEffectsArgs.Length > i)
                {
                    bombEffects.Enqueue(bombEffectsArgs[i]);
                }
            }

            int daturaBombs = 40;
            int cherryBombs = 60;
            int smokeDecoyBombs = 120;

            int daturaBombsCounter = 0;
            int cherryBombsCounter = 0;
            int smokeDecoyBombsCounter = 0;

            int count = Math.Min(bombEffectsArgs.Length, bombCasingsArgs.Length);
            bool isFilled = false;

            for (int i = 0; i < count; i++)
            {
                int effect = bombEffects.Peek();
                int casing = bombCasings.Peek();

                while (true)
                {
                    if (effect + casing == daturaBombs)
                    {
                        daturaBombsCounter++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    }

                    else if (effect + casing == cherryBombs)
                    {
                        cherryBombsCounter++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    }

                    else if (effect + casing == smokeDecoyBombs)
                    {
                        smokeDecoyBombsCounter++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    }

                    else
                    {
                        casing -= 5;
                    }
                }

                if (daturaBombsCounter >= 3 && cherryBombsCounter >= 3 && smokeDecoyBombsCounter >= 3)
                {
                    isFilled = true;
                    break;
                }
            }

            if (isFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {  
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {  
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCounter}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombsCounter}");
        }
    }
}
