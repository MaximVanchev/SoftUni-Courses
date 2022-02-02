using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Car> cars = new Dictionary<string,Car>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] car = Console.ReadLine().Split().ToArray();
                cars.Add(car[0],new Car(car[0], double.Parse(car[1]), double.Parse(car[2])));
            }
            List<string> command = null;
            while ((command = Console.ReadLine().Split().ToList())[0] != "End")
            {
                if (!cars[command[1]].Move(double.Parse(command[2])))
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Value.Model} {item.Value.FuelAmount:F2} {item.Value.TravelledDistance}");
            }
        }
    }
}
