using System;
using System.Threading.Tasks;

namespace TaskContinueWith
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var task = Task.Run(() =>
            {
                long sum = 0;

                for (int i = 0; i < 1000; i++)
                {
                    sum += i;
                }

                return sum;
            }) //Continue with the second task
                .ContinueWith(task =>
            {
                var result = task.Result;

                Console.WriteLine(result);
            })
                .ContinueWith(task => 
            {
                Console.WriteLine("Third task");
            });

            task.Wait();

            // use it from methods

            var taskFromMethod = DoSomeWork();
            var result = taskFromMethod.Result;

            // bu it's better if we make the Main Async Task

            var theSameResult = await DoSomeWork();
        }

        private static Task<int> DoSomeWork()
        {
            return Task.Run(() => 
            { // long operation for example
                return 100;
            });
        }
    }
}
