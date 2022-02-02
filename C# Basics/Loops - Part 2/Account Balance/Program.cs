using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int deposit = int.Parse(Console.ReadLine());
            int numDeposit = 1;
            double sum = 0;
            while (deposit >= numDeposit)
            {
                double check = double.Parse(Console.ReadLine());
                if (check < 0)
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }
                else
                {
                    sum += check;
                    Console.WriteLine($"Increase: {check:F2}");
                }
                numDeposit++;
            }
            Console.WriteLine($"Total: {sum}");
        }
    }
}
