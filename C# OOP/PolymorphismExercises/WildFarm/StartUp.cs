using System;
using WildFarm.Core;
using WildFarm.Core.Contracts;
using WildFarm.IO.Contracts;
using WildFarm.IO.Models;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
