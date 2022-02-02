using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int sudents = int.Parse(Console.ReadLine());
            double priceLightsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());
            int freeBelts = sudents / 6;
            double sum = (priceLightsabers * Math.Ceiling((double)sudents * 110 / 100)) + (priceRobes * sudents) + (priceBelts * (sudents - freeBelts));
            if (sum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(sum - money):F2}lv more.");
            }
        }
    }
}
