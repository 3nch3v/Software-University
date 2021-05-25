using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAwaitTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                int curr = i;

                var task = Task.Run(() =>
                {
                    Console.WriteLine(curr);
                });

                tasks.Add(task);
            }

            //will wait all tasks to be done then will writwe Done!
            await Task.WhenAll(tasks);

            Console.WriteLine("Done!");
        }
    }
}
