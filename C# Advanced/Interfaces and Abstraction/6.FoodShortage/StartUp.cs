using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                List<string> person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (person.Count == 3)
                {
                    Rebel rebel = new Rebel(person[0], int.Parse(person[1]), person[2]);
                    buyers.Add(person[0], rebel);
                }
                else if (person.Count == 4)
                {
                    Citizen citizen = new Citizen(person[0], int.Parse(person[1]), person[2], person[3]);
                    buyers.Add(person[0], citizen);
                }
            }
            string command = null;
            while ((command = Console.ReadLine()) != "End")
            {
                if (buyers.ContainsKey(command))
                {
                    buyers[command].BuyFood();
                }
            }
            int totalFood = 0;
            foreach (var buyer in buyers)
            {
                totalFood += buyer.Value.Food;
            }
            Console.WriteLine(totalFood);
        }
    }
}
