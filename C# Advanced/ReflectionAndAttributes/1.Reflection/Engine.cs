using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (commandInterpreter.Read(input) != null)
                {
                    Console.WriteLine(commandInterpreter.Read(input));
                }
                else
                {
                    break;
                } 
            }
        }
    }
}
