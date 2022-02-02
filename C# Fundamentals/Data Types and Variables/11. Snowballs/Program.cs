using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSnowballs = int.Parse(Console.ReadLine());
            BigInteger biggest = ulong.MinValue;
            short biggestQuality = 0;
            short biggestSnow = 0;
            short biggestTime = 0;
            for (int i = 0; i < numSnowballs; i++)
            {
                short snowballSnow = short.Parse(Console.ReadLine());
                short snowballTime = short.Parse(Console.ReadLine());
                short snowballQuality = short.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime),snowballQuality);  
                if (snowballValue > biggest)
                {
                    biggest = snowballValue; 
                    biggestQuality = snowballQuality;
                    biggestSnow = snowballSnow;
                    biggestTime = snowballTime;
                }
            }
            Console.WriteLine($"{biggestSnow} : {biggestTime} = {biggest} ({biggestQuality})");
        }
    }
}
