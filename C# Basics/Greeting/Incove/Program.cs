using System;

namespace Incove
{
    class Program
    {
        static void Main(string[] args)
        {
            double incove = double.Parse(Console.ReadLine());
            double sm = incove * 2.54;
            Console.WriteLine($"Sm={sm}");
        }
    }
}
