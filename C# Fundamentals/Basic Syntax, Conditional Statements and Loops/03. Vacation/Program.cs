using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            if (type == "Students")
            {
                if (day == "Friday")
                {
                    double sum = people * 8.45;
                    if (people >= 30)
                    {
                        sum = (sum * 85) / 100;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
                else if (day == "Saturday")
                {
                    double sum = people * 9.80;
                    if (people >= 30)
                    {
                        sum = (sum * 85) / 100;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
                else if (day == "Sunday")
                {
                    double sum = people * 10.46;
                    if (people >= 30)
                    {
                        sum = (sum * 85) / 100;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
            }
            else if (type == "Business")
            {
                if (day == "Friday")
                {
                    double sum = people * 10.90;
                    if (people >= 100)
                    {
                        sum = (people - 10)* 10.90;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
                else if (day == "Saturday")
                {
                    double sum = people * 15.60;
                    if (people >= 100)
                    {
                        sum = (people - 10) * 15.60;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
                else if (day == "Sunday")
                {
                    double sum = people * 16;
                    if (people >= 100)
                    {
                        sum = (people - 10) * 16;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
            }
            else if (type == "Regular")
            {
                if (day == "Friday")
                {
                    double sum = people * 15;
                    if (people >= 10 && people <=20)
                    {
                        sum = (sum * 95) / 100;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
                else if (day == "Saturday")
                {
                    double sum = people * 20;
                    if (people >= 10 && people <= 20)
                    {
                        sum = (sum * 95) / 100;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
                else if (day == "Sunday")
                {
                    double sum = people * 22.50;
                    if (people >= 10 && people <= 20)
                    {
                        sum = (sum * 95) / 100;
                    }
                    Console.WriteLine($"Total price: {sum:F2}");
                }
            }
        }
    }
}
