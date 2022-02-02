using System;

namespace Online_Mid_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int employeeEfficiency = 0;
            for (int i = 0; i < 3; i++)
            {
                employeeEfficiency += int.Parse(Console.ReadLine());
            }
            int studentsCount = int.Parse(Console.ReadLine());
            while (studentsCount > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                else
                {
                    studentsCount -= employeeEfficiency;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
