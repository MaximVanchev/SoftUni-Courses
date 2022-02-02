using System;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool pr = num >= 100 && num <= 200 || num == 0;
            if (pr == false)
            {
                Console.WriteLine($"invalid");
            }
        }
    }
}
