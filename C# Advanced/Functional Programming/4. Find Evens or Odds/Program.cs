using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> evenFunk = x => x % 2 == 0;
            Func<int, bool> oddFunk = x => x % 2 == 1 || x % 2 == -1;
            List<int> input = ToIntArray(Console.ReadLine().Split().Select(int.Parse).ToArray());
            string type = Console.ReadLine();
            if (type == "even")
            {
                Print(evenFunk,input);
            }
            else
            {
                Print(oddFunk, input);
            }
        }
        static void Print(Func<int,bool> funk,List<int> input)
        {
            Console.WriteLine(string.Join(" ", input.Where(funk)));
        }
        static List<int> ToIntArray(int[] input)
        {
            List<int> result = new List<int>();
            if (input[0] < input[1])
            {
                for (int i = input[0]; i <= input[1]; i++)
                {
                    result.Add(i);
                } 
            }
            else if(input[0] > input[1])
            {
                for (int i = input[0]; i >= input[1]; i--)
                {
                    result.Add(i);
                }
            }
            else
            {
                result.Add(input[0]);
            }
            return result;
        }
    }
}
