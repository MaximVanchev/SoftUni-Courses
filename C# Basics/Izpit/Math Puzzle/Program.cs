using System;

namespace Math_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int writeCount = 0;
            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {
                        int sum = a + b + c;
                        int sum2 = a * b * c;
                        if (sum == key)
                        {
                            if (a < b && b < c)
                            {
                                Console.WriteLine($"{a} + {b} + {c} = {key}");
                                writeCount++;
                            }
                        }
                        if (sum2 == key)
                        {
                            if (a < b && b < c)
                            {
                                Console.WriteLine($"{a} * {b} * {c} = {key}");
                                writeCount++;
                            }
                        }
                    }
                }
            }
            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {
                        int sum = a + b + c;
                        int sum2 = a * b * c;
                        if (sum == key)
                        {
                            if (a > b && b > c)
                            {

                                Console.WriteLine($"{a} + {b} + {c} = {key}");
                                writeCount++;
                            }
                        }
                        if (sum2 == key)
                        {
                            if (a > b && b > c)
                            {
                                Console.WriteLine($"{a} * {b} * {c} = {key}");
                                writeCount++;
                            }
                        }
                    }
                }
            }
            if (writeCount == 0)
            {
                Console.WriteLine($"No!");
            }
        }
    }
}
