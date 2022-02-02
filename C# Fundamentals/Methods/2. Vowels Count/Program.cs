using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(vowelsCount(input));
        }
        static int vowelsCount(string input)
        {
            int vowelsCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string symbol = input[i].ToString();
                if (symbol == "a" || symbol == "A" || symbol == "e" || symbol == "E" || symbol == "i" || symbol == "I" || symbol == "o" || symbol == "O" || symbol == "u" || symbol == "U")
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
