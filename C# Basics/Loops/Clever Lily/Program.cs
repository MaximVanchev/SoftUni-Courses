using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int toyNumber = 0;
            int sum = 0;
            int sum2 = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum = sum + sum2 + 9;
                    sum2 += 10;
                    continue;
                }
                toyNumber++;
            }
            double finSum = sum + (toyNumber * toyPrice);
            if (finSum >= price)
            {
                Console.WriteLine($"Yes! {(finSum - price):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(price - finSum):F2}");
            }
        }
    }
}
