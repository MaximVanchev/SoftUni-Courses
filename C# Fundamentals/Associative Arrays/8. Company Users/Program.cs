using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();
            string input = null;
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> user = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (company.ContainsKey(user[0]))
                {
                    if (!company[user[0]].Contains(user[1]))
                    {
                        company[user[0]].Add(user[1]); 
                    }
                }
                else
                {
                    company.Add(user[0], new List<string>() { user[1] });
                }
            }
            foreach (var item in company.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var users in item.Value)
                {
                    Console.WriteLine($"-- {users}");
                }
            }
        }
    }
}
