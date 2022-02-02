using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> sides = new SortedDictionary<string, List<string>>();
            string input = null;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    List<string> command = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (!sides.ContainsKey(command[0]))
                    {
                        sides.Add(command[0], new List<string>() {command[1]});
                    }
                }
                else
                {
                    List<string> command = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (var item in sides)
                    {
                        if (sides.ContainsKey(command[1]))
                        {
                            if (item.Value.Contains(command[0]))
                            {
                                sides[item.Key].Remove(command[0]);
                            }
                        }
                    }
                    if (sides.ContainsKey(command[1]))
                    {
                        sides[command[1]].Add(command[0]);
                        Console.WriteLine($"{command[0]} joins the {command[1]} side!");
                    }
                }
            }
            foreach (var item in sides.OrderByDescending(x => x.Value.Count).Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var members in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {members}");
                }
            }
        }
    }
}
