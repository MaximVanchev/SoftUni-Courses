using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            int budget = int.Parse(Console.ReadLine());
            while (true)
            {
                int sum = 0;
                while (budget > sum)
                {
                    sum += int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {country}!");
                country = Console.ReadLine();
                if (country == "End")
                {
                    return;
                }
                budget = int.Parse(Console.ReadLine());
            }
        }
    }
}
