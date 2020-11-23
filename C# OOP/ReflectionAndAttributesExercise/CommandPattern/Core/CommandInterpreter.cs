using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Comands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string comandPostfix = "Command";

        public string Read(string args)
        {
            string[] tokens = args.Split();
            string comandtypeName = tokens[0] + comandPostfix;

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(ICommand)))
                .FirstOrDefault(t => t.Name == comandtypeName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Command type is invalid");
            }

            ICommand command =  Activator.CreateInstance(commandType) as ICommand;

            string res = command.Execute(tokens.Skip(1).ToArray());

            return res;
        }
    }
}
