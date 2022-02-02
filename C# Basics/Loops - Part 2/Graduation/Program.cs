using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int num = 1;
            double sum = 0;
            while (num <= 12)
            {
                double num2 = double.Parse(Console.ReadLine());
                if (num2 < 4)
                {
                    continue;
                }
                sum += num2;
                num++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {(sum/12):F2}");
        }
    }
}
