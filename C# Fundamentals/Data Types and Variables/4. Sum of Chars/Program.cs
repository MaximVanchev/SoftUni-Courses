using System;

namespace _4._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < numLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int intLetter = Convert.ToInt32(letter);
                sum += intLetter;

            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
