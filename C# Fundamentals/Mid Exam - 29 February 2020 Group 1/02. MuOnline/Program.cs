using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            List<string> rooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < rooms.Count; i++)
            {
                List<string> room = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (room[0] == "potion")
                {
                    if (100 - health != 0)
                    {
                        if (100 - health <= Convert.ToInt32(room[1]))
                        {
                            health += 100 - health;
                            Console.WriteLine($"You healed for {100 - health} hp.");
                            Console.WriteLine($"Current health: 100 hp.");
                        }
                        else
                        {
                            health += Convert.ToInt32(room[1]);
                            Console.WriteLine($"You healed for {Convert.ToInt32(room[1])} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You healed for 0 hp.");
                        Console.WriteLine($"Current health: 100 hp.");
                    }
                }
                else if (room[0] == "chest")
                {
                    bitcoins += Convert.ToInt32(room[1]);
                    Console.WriteLine($"You found {Convert.ToInt32(room[1])} bitcoins.");
                }
                else
                {
                    if (Convert.ToInt32(room[1]) < health)
                    {
                        health -= Convert.ToInt32(room[1]);
                        Console.WriteLine($"You slayed {room[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {room[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
