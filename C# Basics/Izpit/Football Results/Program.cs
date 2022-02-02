using System;

namespace Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            int win = 0;
            int lost = 0;
            int drawn = 0;
            for (int i = 0; i < 3; i++)
            {
                string matches = Console.ReadLine();
                if (matches[0] > matches[2])
                {
                    win++;
                }
                else if (matches[0] < matches[2])
                {
                    lost++;
                }
                else if (matches[0] == matches[2])
                {
                    drawn++;
                }
            }
            Console.WriteLine($"Team won {win} games.");
            Console.WriteLine($"Team lost {lost} games.");
            Console.WriteLine($"Drawn games: {drawn}");
        }
    }
}
