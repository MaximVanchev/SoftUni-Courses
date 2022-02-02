using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int a = 0; a <= num; a++)
            {
                for (int b = 0; b <= num; b++)
                {
                    for (int c = 0; c <= num; c++)
                    {
                        int d = a + b + c;
                        if (d == num)
                        {
                            sum++;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
