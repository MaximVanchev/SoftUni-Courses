using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int longestMax = 0;
            string longestNums = null;
            int temp = -1;
            string nums = null;
            int numsCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (temp == numbers[i])
                {
                    nums += $"{numbers[i]} ";
                    numsCount++;
                    if (numsCount > longestMax)
                    {
                        longestMax = numsCount;
                        longestNums = nums;
                    }
                    continue;
                }
                temp = numbers[i];
                nums = $"{numbers[i]} ";
                numsCount = 1;
            }
            Console.WriteLine(longestNums);
        }
    }
}
