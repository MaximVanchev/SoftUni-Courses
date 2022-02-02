using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            Dictionary<string,int> resurces = new Dictionary<string, int>();
            while ((input = Console.ReadLine()) != "stop")
            {
                string resurce = input;
                int quantity = int.Parse(Console.ReadLine());
                if (resurces.ContainsKey(resurce))
                {
                    resurces[resurce] += quantity;
                }
                else
                {
                    resurces.Add(resurce, quantity);
                }
            }
            foreach (var item in resurces)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
