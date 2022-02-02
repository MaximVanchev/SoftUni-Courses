using System;
using System.Linq;

namespace _5._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string finNums = "";

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                int pass = numbers.Length - i - 1;
                int passCount = 0;
                if (pass == 0)
                {
                    finNums += $"{numbers[i]} ";
                    continue;
                }
                for (int j = 1; j <= pass; j++)
                {
                    if (numbers[i] > numbers[i + j])
                    {
                        passCount++;
                    }
                    if (pass == passCount)
                    {
                        finNums += $"{numbers[i]} ";
                    }
                }
            }
            Console.WriteLine(finNums);
        }
    }
}
