using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, FollowersAndFollowing> vlogars = new Dictionary<string, FollowersAndFollowing>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split().ToList())[0] != "Statistics")
            {
                if (command[1] == "joined")
                {
                    if (!vlogars.ContainsKey(command[0]))
                    {
                        vlogars.Add(command[0], new FollowersAndFollowing());
                    }
                }
                else
                {
                    // && !vlogars[command[2]].Followers.Contains(command[0])
                    if (vlogars.ContainsKey(command[0]) && vlogars.ContainsKey(command[2]) && command[0] != command[2])
                    {
                        vlogars[command[0]].Following.Add(command[2]);
                        vlogars[command[2]].Followers.Add(command[0]);
                    }
                }
            }
            int place = 0;
            Console.WriteLine($"The V-Logger has a total of {vlogars.Count} vloggers in its logs.");
            foreach (var vlogar in vlogars.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                place++;
                Console.WriteLine($"{place}. {vlogar.Key} : {vlogar.Value.Followers.Count} followers, {vlogar.Value.Following.Count} following");
                if (place == 1)
                {
                    foreach (var item in vlogar.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    } 
                }
            }
        }
    }
    public class FollowersAndFollowing
    {
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
        public FollowersAndFollowing()
        {
            Followers = new HashSet<string>();
            Following = new HashSet<string>();
        }
    }
}
