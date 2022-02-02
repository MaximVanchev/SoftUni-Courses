using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (input[0] != "end")
            {
                if (input[0] == "swap")
                {
                    long temp = numbers[Convert.ToInt32(input[1])];
                    numbers[Convert.ToInt32(input[1])] = numbers[Convert.ToInt32(input[2])];
                    numbers[Convert.ToInt32(input[2])] = temp;
                }
                else if (input[0] == "multiply")
                {
                    long currentDogit = numbers[Convert.ToInt32(input[1])] * numbers[Convert.ToInt32(input[2])];
                    numbers[Convert.ToInt32(input[1])] = currentDogit;
                }
                else
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
