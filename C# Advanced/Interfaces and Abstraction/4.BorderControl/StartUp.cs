using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> ids = new List<IIdentifiable>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "End")
            {
                if (command.Count == 2)
                {
                    Robot robot = new Robot(command[0], command[1]);
                    ids.Add(robot);
                }
                else if (command.Count == 3)
                {
                    Citizen citizen = new Citizen(command[0], int.Parse(command[1]), command[2]);
                    ids.Add(citizen);
                }
            }
            string specialNum = Console.ReadLine();
            foreach (var id in ids)
            {
                if (id.Id.EndsWith(specialNum))
                {
                    Console.WriteLine(id.Id);
                }
            }
        }
    }
}
