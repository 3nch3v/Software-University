using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string comandArgs = Console.ReadLine();

                if (comandArgs.Contains("Play"))
                {
                    songs.Dequeue();
                }

                else if (comandArgs.Contains("Add"))
                {
                    string newSong = string.Concat(comandArgs.Skip(4));

                    if (!songs.Contains(newSong))
                    {
                        songs.Enqueue(newSong);
                    }

                    else
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                }

                else if (comandArgs.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
