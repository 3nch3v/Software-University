using System;
using System.Collections;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rosesArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack lilies = new Stack();

            foreach (var lilie in liliesArgs)
            {
                lilies.Push(lilie);
            }

            Queue roses = new Queue();

            foreach (var rose in rosesArgs)
            {
                roses.Enqueue(rose);
            }

            int rest = 0;
            int wreath = 0;

            int minCount = Math.Min(lilies.Count, roses.Count);

            for (int i = 0; i < minCount; i++)
            {
                int currLilie = (int)lilies.Peek();
                int currRose = (int)roses.Peek();

                int sum = currLilie + currRose;

                if (sum == 15)
                {
                    wreath++;
                    lilies.Pop();
                    roses.Dequeue();
                }

                else if (sum < 15)
                {
                    rest += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }

                else if (sum > 15)
                {
                    while (sum > 15)
                    {
                        currLilie -= 2;

                        sum = currLilie + currRose;

                        if (sum == 15)
                        {
                            wreath++;
                            lilies.Pop();
                            roses.Dequeue();
                        }

                        else if (sum < 15)
                        {
                            rest += sum;

                            lilies.Pop();
                            roses.Dequeue();
                        }
                    }
                }
            }

            wreath += rest / 15;

            if (wreath >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }

            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }
        }
    }
}
