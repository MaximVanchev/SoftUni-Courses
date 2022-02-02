using System;

namespace _7._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            linePrint(num);
        }
        static void linePrint(int n)
        {
            for (int i = 0; i < n; i++)
            {
                line(n);
                Console.WriteLine();
            }
        }
        static void line(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{n} ");
            }
        }
    }
}
