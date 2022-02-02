using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (chars.ContainsKey(text[i]))
                {
                    chars[text[i]]++;
                }
                else
                {
                    chars.Add(text[i], 1);
                }
            }
            foreach (var item in chars)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s"); 
            }
        }
    }
}
