
using System;
using WildFarm.IO.Contracts;

namespace WildFarm.IO.Models
{
    class ConsoleReader : IReader
    {
        public string Reader()
        {
            return Console.ReadLine();
        }
    }
}
