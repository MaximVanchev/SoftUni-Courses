using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int sum2 = 0;
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                sum += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < num; i++)
            {
                sum2 += int.Parse(Console.ReadLine());
            }
            if (sum == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum}");
            }
            else if (sum > sum2)
            {
                Console.WriteLine($"No, diff = {sum - sum2}");
            }
            else if (sum2 > sum)
            {
                Console.WriteLine($"No, diff = {sum2 - sum}");
            }
        }
    }
}