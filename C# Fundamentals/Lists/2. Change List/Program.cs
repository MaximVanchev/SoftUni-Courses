using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input[0] == 'D')
                {
                    numbers.RemoveAll(n => n == deleteNum(input));
                }
                else
                {
                    insertNum(input,numbers);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
        static int deleteNum(string input)
        {
            string result = null;
            for (int i = 7; i < input.Length; i++)
            {
                result += input[i];
            }
            return Convert.ToInt32(result);
        }
        static void insertNum(string input,List<int> numbers)
        {
            string result = null;
            for (int i = 6; i < input.Length; i++)
            {
                result += input[i];
            }
            List<int> insertNums = result.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            numbers.Insert(insertNums[1], insertNums[0]);
        }
    }
}
