using System;

namespace Izpit
{
    class Program
    {
        static void Main(string[] args)
        {

            double skumriqPrice = double.Parse(Console.ReadLine());
            double cacaPrice = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            int musselsKg = int.Parse(Console.ReadLine());
            double totalPrice = ((skumriqPrice + (skumriqPrice * 0.60)) * palamudKg) + ((cacaPrice + (cacaPrice * 0.80)) * safridKg) + (musselsKg * 7.5);
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
