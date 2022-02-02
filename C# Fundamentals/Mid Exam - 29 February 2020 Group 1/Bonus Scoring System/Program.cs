using System;

namespace Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double maxBonusPoints = int.MinValue;
            double maxAttendances = 0;
            for (int i = 0; i < students; i++)
            {
                double studentAttendances = double.Parse(Console.ReadLine());
                double totalBonus = (double)studentAttendances / lectures * (5 + bonus);
                if (maxBonusPoints < totalBonus)
                {
                    maxBonusPoints =totalBonus;
                    maxAttendances = Math.Ceiling(studentAttendances);
                }
            }
            Console.WriteLine($"Max Bonus: { Math.Ceiling(maxBonusPoints)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}
