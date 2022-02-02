using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            byte Y = byte.Parse(Console.ReadLine());
            int originalValue = N;
            byte targetsPoked = 0;
            while (N >= M)
            {
                if (N == originalValue / 2 && Y != 0)
                {
                    N /= Y;
                    continue;
                }
                N -= M;
                targetsPoked++;
            }
            Console.WriteLine(N);
            Console.WriteLine(targetsPoked);
        }
    }
}
