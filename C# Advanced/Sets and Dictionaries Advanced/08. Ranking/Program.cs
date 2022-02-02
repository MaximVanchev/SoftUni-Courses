using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ExamResults> students = new Dictionary<string, ExamResults>();
            Dictionary<string, string> exams = new Dictionary<string, string>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split(":").ToList())[0] != "end of contests")
            {
                exams.Add(command[0],command[1]);
            }
            List<string> score = null;
            while ((score = Console.ReadLine().Split("=>").ToList())[0] != "end of submissions")
            {
                if (exams.ContainsKey(score[0]) && exams[score[0]] == score[1])
                {
                    if (students.ContainsKey(score[2]))
                    {
                        if (students[score[2]].Exams.ContainsKey(score[0]) && students[score[2]].Exams[score[0]] < int.Parse(score[3]))
                        {
                            students[score[2]].Exams[score[0]] = int.Parse(score[3]);
                        }
                        else if (!students[score[2]].Exams.ContainsKey(score[0]))
                        {
                            students[score[2]].Exams.Add(score[0], int.Parse(score[3]));
                        }
                    }
                    else
                    {
                        students.Add(score[2], new ExamResults(score[0], int.Parse(score[3])));
                    }
                }
            }
            string bestStudent = null;
            int bestScore = 0;
            foreach (var item in students)
            {
                if (bestScore < item.Value.Exams.Values.Sum())
                {
                    bestScore = item.Value.Exams.Values.Sum();
                    bestStudent = item.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestStudent} with total {bestScore} points.");
            Console.WriteLine($"Ranking:");
            foreach (var item in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item.Value.Exams.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item2.Key} -> {item2.Value}");
                }
            }
        }
        public class ExamResults
        {
            public Dictionary<string,int> Exams { get; set; }
            public ExamResults(string exam,int points)
            {
                Exams = new Dictionary<string, int>();
                Exams.Add(exam, points);
            }
        }
    }
}
