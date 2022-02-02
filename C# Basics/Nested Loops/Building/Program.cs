using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            for (int i = a; i > 0; i--)
            {
                for (int e = 0; e < b; e++)
                {
                    if (i == a)
                    {
                        Console.Write($"L{i}{e} ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{e} ");
                    }
                    else if (i % 2 == 1)
                    {
                        Console.Write($"A{i}{e} ");
                    }
                }
                Console.WriteLine();
            }
        }   
    }
}
