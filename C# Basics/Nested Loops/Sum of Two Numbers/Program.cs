using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = num; i <= num2; i++)
            {
                for (int a = num; a <= num2; a++)
                {
                    sum++;
                    for (int b = num; b <= num2; b++)
                    {
                        int c = a + b;
                        if(c == magicNum)
                        {
                            Console.WriteLine($"Combination N:{sum} ({a} + {b} = {c})");
                            return;
                        }
                        sum++;
                    }
                }
            }
            Console.WriteLine($"{sum} combinations - neither equals {magicNum}");
        }
    }
}
    