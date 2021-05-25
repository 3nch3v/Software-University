using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Task {i}");
                    Thread.Sleep(1000);
                }
            });

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"For loop {i}!");
                Thread.Sleep(1000);
            }

            //without wait the task woundn't be compleate
            task.Wait();
        }
    }
}
