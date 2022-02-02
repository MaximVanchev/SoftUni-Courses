using System;

namespace Zoomagazin
{
    class Program
    {
        static void Main(string[] args)
        {
            int kuceta = int.Parse(Console.ReadLine());
            int ostjivotni = int.Parse(Console.ReadLine());
            double obshtasuma = kuceta * 2.5 + ostjivotni*4;
            Console.WriteLine($"{obshtasuma:F2} lv.");
        }
    }
}
