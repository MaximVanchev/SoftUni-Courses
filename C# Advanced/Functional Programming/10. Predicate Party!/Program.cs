using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> command = null;
            Func<string, string, bool> nameCheckStart = (a, b) =>
            {
                    if (b.Length >= a.Length && b.Substring(0, a.Length) == a)
                    {
                        return true;
                    } 
                return false;
            };
            Func<string, string, bool> nameCheckEnd = (a, b) =>
            {
                if (b.Length >= a.Length && b.Substring(b.Length - a.Length,b.Length - 1) == a)
                {
                    return true;
                }
                return false;
            };
            while ((command = Console.ReadLine().Split().ToList())[0] != "Party!")
            {
                if (command[0] == "Double")
                {
                    List<string> currentPeoples = people.ToArray().ToList();
                    if (command[1] == "StartsWith")
                    {                        
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (nameCheckStart(command[2], people[i]))
                            {
                                currentPeoples.Add(people[i]);
                            } 
                        }
                    }
                    else if (command[1] == "EndsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (nameCheckEnd(command[2], people[i]))
                            {
                                currentPeoples.Add(people[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (int.Parse(command[2]) == people[i].Length)
                            {
                                currentPeoples.Add(people[i]);
                            }
                        }
                    }
                    people = currentPeoples;
                }
                else
                {
                    if (command[1] == "StartsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (nameCheckStart(command[2], people[i]))
                            {
                                people.Remove(people[i]);
                            }
                        }
                    }
                    else if (command[1] == "EndsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (nameCheckEnd(command[2], people[i]))
                            {
                                people.Remove(people[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (int.Parse(command[2]) == people[i].Length)
                            {
                                people.Remove(people[i]);
                            }
                        }
                    }
                }
            }
            if (people.Count == 0)
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(", ", people.OrderBy(x => x)));
                Console.WriteLine($" are going to the party!");
            }
        }
    }
}
