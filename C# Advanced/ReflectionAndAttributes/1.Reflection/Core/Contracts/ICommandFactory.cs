
namespace CommandPattern.Core.Contracts
{
    public interface ICommandFactory
    {
        public ICommand CreateCommand(string commandName);
    }
}
