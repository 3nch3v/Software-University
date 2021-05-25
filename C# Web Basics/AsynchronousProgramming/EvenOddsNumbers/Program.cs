using System;
using System.Threading;
using System.Threading.Tasks;

namespace EvenOddsNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var evenNumbers = Task.Run(() => 
            {
                for (int i = 0; i <= 100; i+=2)
                {
                    Console.WriteLine(i);                   
                }

                Thread.Sleep(1000);
            });

            var oddNumbers = Task.Run(() =>
            {
                for (int i = 1; i <= 100; i += 2)
                {
                    Console.WriteLine(i);
                }

                Thread.Sleep(1000);
            });

            Task.WaitAll(evenNumbers, oddNumbers);
        }
    }
}
