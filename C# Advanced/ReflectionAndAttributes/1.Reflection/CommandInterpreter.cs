using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory = new CommandFactory();
        public string Read(string args)
        {
            string[] commandSplit = args.Split();
            string commandName = commandSplit[0];
            string[] commandArgs = commandSplit.Skip(1).ToArray();
            ICommand command = commandFactory.CreateCommand(commandName);
            return command.Execute(commandArgs);
        }
    }
}
