using System;
using System.Threading.Tasks;

namespace TaskReturnsResult
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<long> task = Task.Run(() =>
            {
                long sum = 0;

                for (int i = 0; i < 1000; i++)
                {
                    sum += i;
                }

                return sum;
            });

            for (int i = 0; i < 1000; i++)
            {
                Console.Write($"+");
            }

            var result = task.Result;

            Console.WriteLine($"Result: {result}");
        }
    }
}
