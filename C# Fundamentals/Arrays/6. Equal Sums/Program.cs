using System;
using System.Linq;

namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int passIndexes = -1;
            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                int leftIndex = 0;
                int rightIndex = 0;
                if (i - 1 >= 0)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        leftIndex += numbers[j];
                    } 
                }
                if (i + 1 <= numbers.Length -1)
                {
                    for (int j = i + 1; j <= numbers.Length - 1; j++)
                    {
                        rightIndex += numbers[j];
                    } 
                }
                if (leftIndex == rightIndex)
                {
                    passIndexes = i;
                }
            }
            if (passIndexes == -1)
            {
                Console.WriteLine($"no");
            }
            else
            {
                Console.WriteLine(passIndexes);
            }
        }
    }
}
