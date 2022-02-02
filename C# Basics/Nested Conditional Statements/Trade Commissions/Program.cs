using System;

namespace Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sell = double.Parse(Console.ReadLine());
            if (city == "Sofia")
            {
                if (sell >= 0 && sell <= 500)
                {
                    Console.WriteLine($"{((sell * 5) / 100):F2}");
                }
                else if (sell > 500 && sell <= 1000)
                {
                    Console.WriteLine($"{((sell * 7) / 100):F2}");
                }
                else if (sell > 1000 && sell <= 10000)
                {
                    Console.WriteLine($"{((sell * 8) / 100):F2}");
                }
                else if (sell > 10000)
                {
                    Console.WriteLine($"{((sell * 12) / 100):F2}");
                }
                else
                {
                    Console.WriteLine($"error");
                }
            }
            else if (city == "Varna")
            {
                if (sell >= 0 && sell <= 500)
                {
                    Console.WriteLine($"{((sell * 4.5) / 100):F2}");
                }
                else if (sell > 500 && sell <= 1000)
                {
                    Console.WriteLine($"{((sell * 7.5) / 100):F2}");
                }
                else if (sell > 1000 && sell <= 10000)
                {
                    Console.WriteLine($"{((sell * 10) / 100):F2}");
                }
                else if (sell > 10000)
                {
                    Console.WriteLine($"{((sell * 13) / 100):F2}");
                }
                else
                {
                    Console.WriteLine($"error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sell >= 0 && sell <= 500)
                {
                    Console.WriteLine($"{((sell * 5.5) / 100):F2}");
                }
                else if (sell > 500 && sell <= 1000)
                {
                    Console.WriteLine($"{((sell * 8) / 100):F2}");
                }
                else if (sell > 1000 && sell <= 10000)
                {
                    Console.WriteLine($"{((sell * 12) / 100):F2}");
                }
                else if (sell > 10000)
                {
                    Console.WriteLine($"{((sell * 14.5) / 100):F2}");
                }
                else
                {
                    Console.WriteLine($"error");
                }
            }
            else
            {
                Console.WriteLine($"error");
            }
        }
    }
}
