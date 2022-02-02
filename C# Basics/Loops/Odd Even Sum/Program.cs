using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int sum2 = 0;
            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                {
                    sum2 += int.Parse(Console.ReadLine());
                    continue;
                }
                sum += int.Parse(Console.ReadLine());
            }
            if (sum == sum2)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else if (sum > sum2)
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {sum - sum2}");
            }
            else if (sum2 > sum)
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {sum2 - sum}");
            }
        }
    }
}
