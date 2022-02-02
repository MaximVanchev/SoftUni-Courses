using System;
using System.Linq;

namespace _8._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j <= numbers.Length - 1; j++)
                {
                    if (num == numbers[i] + numbers[j])
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                        numbers[i] = -200;
                        numbers[j] = -300;
                    }
                }
            }
        }
    }
}
