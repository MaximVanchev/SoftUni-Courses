using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();
            foreach (string word in text)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (charsCount.ContainsKey(word[i]))
                    {
                        charsCount[word[i]]++;
                    }
                    else
                    {
                        charsCount.Add(word[i], 1);
                    }
                }
            }
            foreach (var item in charsCount.OrderByDescending(x => x.Value).ToList())
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
