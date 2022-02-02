using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                List<string> student = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Students newStudent = new Students();
                newStudent.firstName = student[0];
                newStudent.secondName = student[1];
                newStudent.grade = Convert.ToDouble(student[2]);
                students.Add(newStudent);
            }
            Console.WriteLine(string.Join(Environment.NewLine,students.OrderByDescending(x => x.grade)));
        }
    }
    public class Students
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public double grade { get; set; }

        public override string ToString()
        {
            return $"{firstName} {secondName}: {grade:F2}";
        }
    }
}
