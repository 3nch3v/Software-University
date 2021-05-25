using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var currunt = i;

                var task = Task.Run(() =>
                {
                    Console.WriteLine($"Task {currunt}");
                });

                list.Add(task);
            }

            Task.WaitAll(list.ToArray());
            Thread.Sleep(1000);
            Console.WriteLine("Done");
        }
    }
}
