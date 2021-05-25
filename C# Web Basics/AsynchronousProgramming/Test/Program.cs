using System;
using System.Linq;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 10000).ToList();

            //We start 4 thread -> all of them asking for information about the count 

            for (int i = 0; i < 4; i++)
            {
                new Thread(() =>
                {
                    while (list.Count > 0)
                    {
                        list.Remove(list.Count - 1);
                    }
                }).Start();
            }

            //out of range exeption 

            //the solution is to look the list

            for (int i = 0; i < 4; i++)
            {
                new Thread(() =>
                {
                    lock (list)
                    {
                        while (list.Count > 0)
                        {
                            list.Remove(list.Count - 1);
                        }
                    }
                }).Start();
            }
        }
    }
}
