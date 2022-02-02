using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> specialNums = new List<int>();
            foreach (int i in numbers)
            {
                if (i > AverageNumber(numbers))
                {
                    specialNums.Add(i);
                }
            }
            if (specialNums.Count == 0)
            {
                Console.WriteLine($"No");
            }
            else if (specialNums.Count <= 5)
            {
                specialNums.Sort();
                specialNums.Reverse();
                Console.WriteLine(string.Join(" ", specialNums));
            }
            else
            {
                while (specialNums.Count != 5)
                {
                    int minValue = int.MaxValue;
                    int minIndex = 0;
                    for (int i = 0; i < specialNums.Count; i++)
                    {
                        if (minValue > specialNums[i])
                        {
                            minValue = specialNums[i];
                            minIndex = i;
                        }
                    }
                    specialNums.RemoveAt(minIndex);
                }
                specialNums.Sort();
                specialNums.Reverse();
                Console.WriteLine(string.Join(" ", specialNums));
            }
        }
        public static double AverageNumber(List<int> nums)
        {
            double result = 0;
            foreach (int i in nums)
            {
                result += i;
            }
            result /= nums.Count;
            return result;
        }
    }
}
