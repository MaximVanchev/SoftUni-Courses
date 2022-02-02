using System;

namespace _4._Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = num; num <= num2; num++)
            {
                Console.Write($"{num} ");
                sum += num;
               
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
