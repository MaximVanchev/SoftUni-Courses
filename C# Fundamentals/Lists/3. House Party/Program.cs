using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsNum = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            for (int i = 0; i < commandsNum; i++)
            {
                List<string> command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string currentDigit = $"{command[1]} {command[2]}";
                if (currentDigit == "is not")
                {

                    foreach (string j in guestList)
                    {
                        if (command[0] == j)
                        {
                            guestList.Remove(command[0]);
                            break;
                        }
                        else
                        {
                            if (j == guestList[guestList.Count -1])
                            {
                                Console.WriteLine($"{command[0]} is not in the list!");
                            } 
                        }
                    }
                }
                else
                {
                    if (guestList.Count > 0)
                    {
                        foreach (string j in guestList)
                        {
                            if (command[0] == j)
                            {
                                Console.WriteLine($"{command[0]} is already in the list!");
                                break;
                            }
                            else
                            {
                                if (j == guestList[guestList.Count - 1])
                                {
                                    guestList.Add(command[0]);
                                    break;
                                }
                            }
                        } 
                    }
                    else
                    {
                        guestList.Add(command[0]);
                    }
                }
            }
            foreach (var item in guestList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
