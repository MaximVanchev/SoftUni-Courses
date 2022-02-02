using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int totalSum = 0;
            if (input[0].Length == input[1].Length)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    totalSum += Convert.ToInt32(input[0][i]) * Convert.ToInt32(input[1][i]);
                }
            }
            else if (input[0].Length > input[1].Length)
            {
                for (int i = 0; i < input[1].Length; i++)
                {
                    totalSum += Convert.ToInt32(input[0][i]) * Convert.ToInt32(input[1][i]);
                }
                for (int j = input[1].Length; j < input[0].Length; j++)
                {
                    totalSum += Convert.ToInt32(input[0][j]);
                }
            }
            else
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    totalSum += Convert.ToInt32(input[0][i]) * Convert.ToInt32(input[1][i]);
                }
                for (int j = input[0].Length; j < input[1].Length; j++)
                {
                    totalSum += Convert.ToInt32(input[1][j]);
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
