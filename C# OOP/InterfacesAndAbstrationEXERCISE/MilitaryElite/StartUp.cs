using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Core;
using MilitaryElite.Core.Contarcts;
using MilitaryElite.Interfaces;
using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
