using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                int n = int.Parse(Console.ReadLine());
                sum += n;
            }
            Console.WriteLine(sum);
        }
    }
}
