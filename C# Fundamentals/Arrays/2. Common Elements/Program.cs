using System;

namespace _2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLineOne = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] inputLineTwo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var inputTwo in inputLineTwo)
            {
                foreach (var inputOne in inputLineOne)
                {
                    if (inputOne == inputTwo)
                    {
                        Console.Write($"{inputOne} ");
                    }
                }
            }
        }
    }
}
