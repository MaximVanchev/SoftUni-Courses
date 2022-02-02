using System;

namespace _2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string numString = Console.ReadLine();
            int num = int.Parse(numString);
            int sum = 0;
            for (int i = 1; i <= numString.Length; i++)
            {
                int currentDigit = num % 10;
                num = (num - currentDigit) / 10;
                sum += currentDigit;
            }
            Console.WriteLine(sum);
        }
    }
}
    