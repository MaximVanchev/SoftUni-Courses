using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] arrayOne = new int[input];
            int[] arrayTwo = new int[input];
            int arrayCountOne = 0;
            int arrayCountTwo = 0;
            for (int i = 1; i <= input; i++)
            {
                string stringNums = Console.ReadLine();
                int[] numbers = stringNums.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (int j in numbers)
                {
                    if (i % 2 == 0 && j == numbers[1])
                    {
                        arrayOne[arrayCountOne] = j;
                        arrayCountOne++;

                    }
                    else if (i % 2 == 0 && j == numbers[0])
                    {
                        arrayTwo[arrayCountTwo] = j;
                        arrayCountTwo++;
                    }
                    else if (j == numbers[0])
                    {
                        arrayOne[arrayCountOne] = j;
                        arrayCountOne++;
                    }
                    else if (j == numbers[1])
                    {
                        arrayTwo[arrayCountTwo] = j;
                        arrayCountTwo++;
                    }
                } 
            }
            foreach (int numbers in arrayOne)
            {
                Console.Write($"{numbers} ");
            }
            Console.WriteLine();
            foreach (int numbers in arrayTwo)
            {
                Console.Write($"{numbers} ");
            }
        }
    }
}
