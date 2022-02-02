using System;

namespace _9._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int sum = 0;
            while (yield >= 100)
            {
                days++;
                sum += yield - 26;
                yield -= 10;
            }
            if (days != 0)
            {
                sum -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(sum);
        }
    }
}

