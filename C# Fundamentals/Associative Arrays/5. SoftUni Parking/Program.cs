using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registered = new Dictionary<string, string>();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                List<string> command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (command[0] == "register")
                {
                    if (registered.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registered[command[1]]}");
                    }
                    else
                    {
                        registered.Add(command[1],command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                }
                else
                {
                    if (registered.ContainsKey(command[1]))
                    {
                        registered.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                }
            }
            foreach (var item in registered)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
