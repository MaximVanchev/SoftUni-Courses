using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _5._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Teams> teams = new List<Teams>();
            int teamsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < teamsCount; i++)
            {
                List<string> command = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (teams.Any(x => x.teamName == command[1]))
                {
                    Console.WriteLine($"Team {command[1]} was already created!");
                }
                else if (teams.Any(x => x.creatorName == command[0]))
                {
                    Console.WriteLine($"{command[0]} cannot create another team!");
                }
                else
                {
                    Teams newTeam = new Teams(command[0], command[1]);
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {command[1]} has been created by {command[0]}!");
                }
            }
            string input = null;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                List<string> command = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!teams.Any(x => x.teamName == command[1]))
                {
                    Console.WriteLine($"Team {command[1]} does not exist!");
                }
                else if (teams.Any(x => x.creatorName == command[0]) || teams.Any(x => x.teamMembers.Contains(command[0])))
                {
                    Console.WriteLine($"Member {command[0]} cannot join team {command[1]}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.teamName == command[1]);
                    teams[index].teamMembers.Add(command[0]);
                }
            }
            var teamsToDisband = teams.FindAll(x => x.teamMembers.Count == 0).OrderBy(x => x.teamName).ToList();
            List<Teams> validTeams = teams.FindAll(x => x.teamMembers.Count > 0).OrderBy(x => x.teamName).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,validTeams.OrderByDescending(x => x.teamMembers.Count).ThenBy(x => x.teamName)));
            Console.WriteLine($"Teams to disband:");
            foreach (var i in teamsToDisband.OrderBy(x => x.teamName))
            {
                Console.WriteLine(i.teamName);
            }
        }
    }
    public class Teams
    {
        public string creatorName { get; set; }

        public string teamName { get; set; }

        public List<string> teamMembers;
        public Teams(string creator,string team)
        {
            creatorName = creator;
            teamName = team;
            teamMembers = new List<string>();
        }
        public override string ToString()
        {
            string text = null;
            text += teamName + Environment.NewLine;
            text += "- " + creatorName + Environment.NewLine;
            for (int i = 0; i < teamMembers.Count; i++)
            {
                if (i == teamMembers.Count - 1)
                {
                    text += "-- " + teamMembers[i];
                }
                else
                {
                    text += "-- " + teamMembers[i] + Environment.NewLine; 
                }
            }
            return text;
        }
    }
}
