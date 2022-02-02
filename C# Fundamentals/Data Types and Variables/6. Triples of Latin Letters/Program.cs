using System;

namespace _6._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstLetter = 0; firstLetter < n; firstLetter++)
            {
                for (int secondLetter = 0; secondLetter < n; secondLetter++)
                {
                    for (int thirdLetter = 0; thirdLetter < n; thirdLetter++)
                    {
                        Console.WriteLine($"{(char)('a' + firstLetter)}{(char)('a' + secondLetter)}{(char)('a' + thirdLetter)}");
                    }
                }
            }
        }
    }
}
