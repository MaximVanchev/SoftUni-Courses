using System;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string pr = Console.ReadLine();
            string city = Console.ReadLine();
            double kl = double.Parse(Console.ReadLine());
            if (city == "Sofia")
            {
                if (pr == "coffee")
                {
                    Console.WriteLine(kl * 0.50);   
                }
                else if (pr == "water")
                {
                    Console.WriteLine(kl * 0.80);
                }
                else if (pr == "beer")
                {
                    Console.WriteLine(kl * 1.20);
                }
                else if (pr == "sweets")
                {
                    Console.WriteLine(kl * 1.45);
                }
                else if (pr == "peanuts")
                {
                    Console.WriteLine(kl * 1.60);
                }
            }
            else if (city == "Plovdiv")
            {
                if (pr == "coffee")
                {
                    Console.WriteLine(kl * 0.40);
                }
                else if (pr == "water")
                {
                    Console.WriteLine(kl * 0.70);
                }
                else if (pr == "beer")
                {
                    Console.WriteLine(kl * 1.15);
                }
                else if (pr == "sweets")
                {
                    Console.WriteLine(kl * 1.30);
                }
                else if (pr == "peanuts")
                {
                    Console.WriteLine(kl * 1.50);
                }
            }
            else if (city == "Varna")
            {
                if (pr == "coffee")
                {
                    Console.WriteLine(kl * 0.45);
                }
                else if (pr == "water")
                {
                    Console.WriteLine(kl * 0.70);
                }
                else if (pr == "beer")
                {
                    Console.WriteLine(kl * 1.10);
                }
                else if (pr == "sweets")
                {
                    Console.WriteLine(kl * 1.35);
                }
                else if (pr == "peanuts")
                {
                    Console.WriteLine(kl * 1.55);
                }
            }
        }
    }
}
