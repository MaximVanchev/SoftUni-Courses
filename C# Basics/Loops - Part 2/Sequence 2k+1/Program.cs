using System;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            while (n >= num)
            {
                Console.WriteLine(num);
                num = num * 2 + 1;
            }
        }
    }
}
