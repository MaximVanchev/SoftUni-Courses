using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, StudentResults> students = new SortedDictionary<string, StudentResults>();
            SortedDictionary<string, int> languageCount = new SortedDictionary<string, int>();
            string input = null;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                List<string> student = input.Split("-", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (students.ContainsKey(student[0]))
                {
                    if (student[1] == "banned")
                    {
                        students.Remove(student[0]);
                    }
                    else
                    {
                        if (languageCount.ContainsKey(student[1]))
                        {
                            languageCount[student[1]]++;
                        }
                        else
                        {
                            languageCount.Add(student[1], 1);
                        }
                        if (students[student[0]].Points < Convert.ToInt32(student[2]))
                        {
                            students[student[0]].Points = Convert.ToInt32(student[2]);
                            students[student[0]].Language = student[1];
                        } 
                    }
                }
                else
                {
                    students.Add(student[0], new StudentResults(student[1],Convert.ToInt32(student[2])));
                    if (languageCount.ContainsKey(student[1]))
                    {
                        languageCount[student[1]]++;
                    }
                    else
                    {
                        languageCount.Add(student[1], 1);
                    }
                }
            }
            Console.WriteLine($"Results:");
            foreach (var item in students.OrderByDescending(x => x.Value.Points))
            {
                Console.WriteLine($"{item.Key} | {item.Value.Points}");
            }
            Console.WriteLine($"Submissions:");
            foreach (var item in languageCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
    public class StudentResults
    {
        public string Language { get; set; }
        public int Points { get; set; }
        public StudentResults(string language,int points)
        {
            Language = language;
            Points = points;
        }
    }
}
