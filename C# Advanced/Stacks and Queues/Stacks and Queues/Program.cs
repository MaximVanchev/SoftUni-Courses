using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            foreach (var item in inputNumbers)
            {
                numbers.Push(item);
            }
            for (int i = 0; i < input[1]; i++)
            {
                numbers.Pop();
            }
            if (numbers.Contains(input[2]))
            {
                Console.WriteLine($"true");
            }
            else
            {
                if (numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min()); 
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
