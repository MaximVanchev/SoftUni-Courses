using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = new Pizza(Console.ReadLine().Split().ToArray()[1]);
                List<string> dough = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                pizza.Dough = new Dough(dough[1], dough[2], decimal.Parse(dough[3]));
                List<string> command = null;
                while ((command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "END")
                {
                    pizza.AddTopping(new Topping(command[1], decimal.Parse(command[2])));
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
