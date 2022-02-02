using System;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char startSymbol = char.Parse(Console.ReadLine());
            char endSymbol = char.Parse(Console.ReadLine());
            Console.WriteLine(charactersPrintInRange(startSymbol,endSymbol));
        }
        static string charactersPrintInRange(int start , int end)
        {
            string result = null;

            if (end > start)
            {
                for (int i = start + 1; i < end; i++)
                {
                    char symbol = Convert.ToChar(i);
                    result += $"{symbol} ";
                } 
            }
            else
            {
                for (int i = end + 1; i < start; i++)
                {
                    char symbol = Convert.ToChar(i);
                    result += $"{symbol} ";
                }
            }
            return result;
        }
    }
}
