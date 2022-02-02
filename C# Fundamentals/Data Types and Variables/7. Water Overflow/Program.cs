using System;

namespace _7._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int sum = 0;
            int capacity = 255;
            for (int i = 0; i < lines; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (liters <= capacity)
                {
                    sum += liters;
                    capacity -= liters;
                }
                else
                {
                    Console.WriteLine($"Insufficient capacity!");
                }
            }
            Console.WriteLine(sum);
        }
    }
}
