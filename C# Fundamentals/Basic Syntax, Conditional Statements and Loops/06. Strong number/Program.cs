using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string numString = Console.ReadLine();
            int num = int.Parse(numString);
            int sum = 0;
            int tempNum = num;
            for (int i = 0; i < numString.Length; i++)
            {
                int fact = 1;

                int currentDigit = num % 10;
                num = (num - currentDigit) / 10;
                for (int a = 1; a <= currentDigit; a++)
                {
                    fact *= a;

                }
                sum += fact;
            }
            if (tempNum == sum)
            {
                Console.WriteLine($"yes");
            }
            else
            {
                Console.WriteLine($"no");
            }
        }
    }
}