using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input = null;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> course = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (courses.ContainsKey(course[0]))
                {
                    courses[course[0]].Add(course[1]);
                }
                else
                {
                    courses.Add(course[0], new List<string>() {course[1]});
                }
            }
            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var members in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {members}");
                }
            }
        }
    }
}
