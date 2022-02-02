using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            
            double sum = 0;
            while (command != "Start")
            {
                double money = double.Parse(command);
                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    sum += money;   
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money:F2}");
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "Nuts")
                {
                    if (sum >= 2.0)
                    {
                        sum -= 2.0;
                        Console.WriteLine($"Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (command == "Water")
                {
                    if (sum >= 0.7)
                    {
                        sum -= 0.7;
                        Console.WriteLine($"Purchased water");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (command == "Crisps")
                {
                    if (sum >= 1.5)
                    {
                        sum -= 1.5;
                        Console.WriteLine($"Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (command == "Soda")
                {
                    if (sum >= 0.8)
                    {
                        sum -= 0.8;
                        Console.WriteLine($"Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (command == "Coke")
                {
                    if (sum >= 1.0)
                    {
                        sum -= 1.0;
                        Console.WriteLine($"Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid product");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
