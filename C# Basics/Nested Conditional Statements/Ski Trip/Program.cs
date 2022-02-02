using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string pm = Console.ReadLine();
            string op = Console.ReadLine();
            if (pm == "room for one person")
            {
                double cena = (day-1) * 18.00;
                if (op == "positive")
                {
                    Console.WriteLine($"{(cena + (cena * 0.25)):F2}");
                }
                else if (op == "negative")
                {
                    Console.WriteLine($"{(cena - (cena * 0.10)):F2}");
                }
            }
            else if (pm == "apartment")
            {
                double cena = (day-1) * 25.00;
                if (day < 10)
                {
                    double cena2 = cena - (cena * 0.30);
                    if (op == "positive")
                    {
                        Console.WriteLine($"{(cena2 + (cena2 * 0.25)):F2}");
                    }
                    else if (op == "negative")
                    {
                        Console.WriteLine($"{(cena2 - (cena2 * 0.10)):F2}");
                    }
                }
                else if (day >= 10 && day <= 15)
                {
                    double cena2 = cena - (cena * 0.35);
                    if (op == "positive")
                    {
                        Console.WriteLine($"{(cena2 + (cena2 * 0.25)):F2}");
                    }
                    else if (op == "negative")
                    {
                        Console.WriteLine($"{(cena2 - (cena2 * 0.10)):F2}");
                    }
                }
                else if (day > 15)
                {
                    double cena2 = cena - (cena * 0.50);
                    if (op == "positive")
                    {
                        Console.WriteLine($"{(cena2 + (cena2 * 0.25)):F2}");
                    }
                    else if (op == "negative")
                    {
                        Console.WriteLine($"{(cena2 - (cena2 * 0.10)):F2}");
                    }
                }
            }
            else if (pm == "president apartment")
            {
                double cena = (day-1) * 35.00;
                if (day < 10)
                {
                    double cena2 = cena - (cena * 0.10);
                    if (op == "positive")
                    {
                        Console.WriteLine($"{(cena2 + (cena2 * 0.25)):F2}");
                    }
                    else if (op == "negative")
                    {
                        Console.WriteLine($"{(cena2 - (cena2 * 0.10)):F2}");
                    }
                }
                else if (day >= 10 && day <= 15)
                {
                    double cena2 = cena - (cena * 0.15);
                    if (op == "positive")
                    {
                        Console.WriteLine($"{(cena2 + (cena2 * 0.25)):F2}");
                    }
                    else if (op == "negative")
                    {
                        Console.WriteLine($"{(cena2 - (cena2 * 0.10)):F2}");
                    }
                }
                else if (day > 15)
                {
                    double cena2 = cena - (cena * 0.20);
                    if (op == "positive")
                    {
                        Console.WriteLine($"{(cena2 + (cena2 * 0.25)):F2}");
                    }
                    else if (op == "negative")
                    {
                        Console.WriteLine($"{(cena2 - (cena2 * 0.10)):F2}");
                    }
                }
            }   
        }
    }
}
