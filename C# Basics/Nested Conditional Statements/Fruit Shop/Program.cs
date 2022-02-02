using System;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string food = Console.ReadLine();
            string day = Console.ReadLine();
            double kl = double.Parse(Console.ReadLine());
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (food)
                {
                    case "banana": Console.WriteLine($"{kl * 2.50:F2}");break;
                    case "apple": Console.WriteLine($"{kl * 1.20:F2}");break;
                    case "orange": Console.WriteLine($"{kl * 0.85:F2}");break;
                    case "grapefruit": Console.WriteLine($"{kl * 1.45:F2}");break;
                    case "kiwi": Console.WriteLine($"{kl * 2.70:F2}");break;
                    case "pineapple": Console.WriteLine($"{kl * 5.50:F2}");break;
                    case "grapes": Console.WriteLine($"{kl * 3.85:F2}");break;
                    default: Console.WriteLine($"error");break;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (food)
                {
                    case "banana": Console.WriteLine($"{kl * 2.70:F2}"); break;
                    case "apple": Console.WriteLine($"{kl * 1.25:F2}"); break;
                    case "orange": Console.WriteLine($"{kl * 0.90:F2}"); break;
                    case "grapefruit": Console.WriteLine($"{kl * 1.60:F2}"); break;
                    case "kiwi": Console.WriteLine($"{kl * 3.00:F2}"); break;
                    case "pineapple": Console.WriteLine($"{kl * 5.60:F2}"); break;
                    case "grapes": Console.WriteLine($"{kl * 4.20:F2}"); break;
                    default: Console.WriteLine($"error"); break;
                }
            }
            else
            {
                Console.WriteLine($"error");
            }
        }
    }
}
