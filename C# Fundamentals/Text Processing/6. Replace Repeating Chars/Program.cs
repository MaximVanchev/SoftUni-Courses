using System;
using System.Text;

namespace _6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char currentChar = new char();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != currentChar)
                {
                    sb.Append(text[i]);
                    currentChar = text[i];
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
