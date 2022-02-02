using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>() {grade});
                }
            }
            foreach (var item in students.OrderByDescending(x => x.Value.Average()).Where(x => x.Value.Average() >= 4.5))
            {
                double averageGrade = item.Value.Sum() / item.Value.Count;
                Console.WriteLine($"{item.Key} -> {averageGrade:F2}"); 
            }
        }
    }
}
