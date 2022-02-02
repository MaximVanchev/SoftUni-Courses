using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    numbers.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    numbers.Pop();
                }
                else if (input[0] == 3)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max()); 
                    }
                }
                else
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min()); 
                    }
                }
            }
            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", numbers)); 
            }
        }
    }
}
