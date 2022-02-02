using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int num = 1;
            int num3 = 0;
            double sum = 0;
            while (num <= 12)
            {
                double num2 = double.Parse(Console.ReadLine());
                if (num2 < 4)
                {
                    num3++;
                    if (num3 == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {num} grade");
                        return;
                    }
                    continue;
                }
                sum += num2;
                num++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {(sum / 12):F2}");
        }
    }
}
