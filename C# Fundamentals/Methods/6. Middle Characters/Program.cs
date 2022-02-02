using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length % 2 == 0)
            {
                Console.WriteLine(middleCharacters(input));
            }
            else
            {
                Console.WriteLine(middleCharacter(input));
            }
        }
        static string middleCharacters(string input)
        {
            string result = input[input.Length / 2 - 1].ToString();

            result += input[input.Length / 2];

            return result;
        }
        static string middleCharacter(string input)
        {
            string result = Convert.ToString(input[input.Length / 2]);
            return result;
        }
    }
}
