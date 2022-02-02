using System;

namespace Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            if (month == "march" || month == "april" || month == "may")
            {
                if (time == "day")
                {
                    double price = 10.50;
                    if (people >= 4)
                    {
                        price -= price * 0.10;
                    }
                    if (hours >= 5)
                    {
                        price -= price * 0.50;
                    }
                    Console.WriteLine($"Price per person for one hour: {price:F2}");
                    Console.WriteLine($"Total cost of the visit: {(price * people) * hours:F2}");
                }
                else if (time == "night")
                {
                    double price = 8.40;
                    if (people >= 4)
                    {
                        price -= price * 0.10;
                    }
                    if (hours >= 5)
                    {
                        price -= price * 0.50;
                    }
                    Console.WriteLine($"Price per person for one hour: {price:F2}");
                    Console.WriteLine($"Total cost of the visit: {(price * people) * hours:F2}");
                }
            }
            else if (month == "june" || month == "july" || month == "august")
            {
                if (time == "day")
                {
                    double price = 12.60;
                    if (people >= 4)
                    {
                        price -= price * 0.10;
                    }
                    if (hours >= 5)
                    {
                        price -= price * 0.50;
                    }
                    Console.WriteLine($"Price per person for one hour: {price:F2}");
                    Console.WriteLine($"Total cost of the visit: {(price * people) * hours:F2}");
                }
                else if (time == "night")
                {
                    double price = 10.20;
                    if (people >= 4)
                    {
                        price -= price * 0.10;
                    }
                    if (hours >= 5)
                    {
                        price -= price * 0.50;
                    }
                    Console.WriteLine($"Price per person for one hour: {price:F2}");
                    Console.WriteLine($"Total cost of the visit: {(price * people) * hours:F2}");
                }
            }
        }
    }
}
