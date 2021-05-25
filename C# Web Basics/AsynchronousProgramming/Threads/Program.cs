using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before to start the thread");

            var thread = new Thread(() => 
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($".");
                    Thread.Sleep(1000);
                }
            });

            thread.Start();

            Console.WriteLine("I'm writting after started the thread.");

            Console.WriteLine("Before to start the second thread");

            var threadTwo = new Thread(() =>
            {
                for (int i = 10; i > 0; i--)
                {
                    Console.Write($"+");
                    Thread.Sleep(100);
                }
            });

            threadTwo.Start();

            Console.WriteLine("I'm waiting for threadTwo to be done.");

            Console.WriteLine("Before to start the thirth thread");

            var threadThree = new Thread(() =>
            {
                for (int i = 10; i > 0; i--)
                {
                    Console.Write($"-");
                    Thread.Sleep(100);
                }
            });

            threadThree.Start();
            threadThree.Join();

            Console.WriteLine("I'm waiting for threadThree to be done.");
        }
    }
}
