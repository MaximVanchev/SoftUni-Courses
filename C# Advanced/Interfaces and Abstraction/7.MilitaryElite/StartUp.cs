using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IPrivate> privates = new Dictionary<string, IPrivate>();
            List<string> command = new List<string>();
            while ((command = Console.ReadLine().Split().ToList())[0] != "End")
            {
                if (command[0] == "Private")
                {
                    Private @private = new Private(command[1], command[2], command[3], decimal.Parse(command[4]));
                    privates.Add(command[1], @private);
                    Console.WriteLine(@private);
                }
                else if (command[0] == "Spy")
                {
                    Spy spy = new Spy(command[1], command[2], command[3], int.Parse(command[4]));
                    Console.WriteLine(spy);
                }
                else if (command[0] == "LieutenantGeneral")
                {
                    List<IPrivate> ListOfPrivates = new List<IPrivate>();
                    for (int i = 5; i < command.Count; i++)
                    {
                        ListOfPrivates.Add(privates[command[i]]);
                    }
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(command[1], command[2], command[3], decimal.Parse(command[4]), ListOfPrivates);
                    Console.WriteLine(lieutenantGeneral);
                }
                else if (command[0] == "Engineer")
                {
                    try
                    {
                        Engineer engineer = new Engineer(command[1], command[2], command[3], decimal.Parse(command[4]), command[5]);
                        for (int i = 6; i < command.Count; i += 2)
                        {
                            engineer.Repairs.Add(new Repair(command[i], int.Parse(command[i + 1])));
                        }
                        Console.WriteLine(engineer);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                else if (command[0] == "Commando")
                {
                    Commando commando = new Commando(command[1], command[2], command[3], decimal.Parse(command[4]), command[5]);
                    for (int i = 6; i < command.Count; i += 2)
                    {
                        try
                        {
                            commando.Missions.Add(new Mission(command[i], command[i + 1]));
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    Console.WriteLine(commando);
                }
            }
        }
    }
}
