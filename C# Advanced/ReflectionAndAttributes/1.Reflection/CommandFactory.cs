using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName)
        {
            Type commandType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(x => x.Name.Contains(commandName));

            return (ICommand)Activator.CreateInstance(commandType);
        }
    }
}
