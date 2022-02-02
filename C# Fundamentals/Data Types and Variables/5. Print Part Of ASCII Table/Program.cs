using System;

namespace _5._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int lastIndex = int.Parse(Console.ReadLine());
            string print = "";
            for (int i = startIndex; i <= lastIndex; i++)
            {
                char symbol = Convert.ToChar(i);
                print = $"{print}{symbol} ";
            }
            Console.WriteLine(print);
        }
    }
}
