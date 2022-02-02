using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                List<string> car = Console.ReadLine().Split().ToList();
                cars.Add(new Car(car[0],double.Parse(car[1]), double.Parse(car[2]), double.Parse(car[3]), car[4], double.Parse(car[5]), double.Parse(car[6]), double.Parse(car[7]), double.Parse(car[8]), double.Parse(car[9]), double.Parse(car[10]), double.Parse(car[11]), double.Parse(car[12])));
            }
            string command = Console.ReadLine();
            foreach (var item in cars)
            {
                if (command == "fragile")
                {
                    if (item.Cargo.Type == "fragile" && (item.Tire.Tire1Pressure < 1 || item.Tire.Tire2Pressure < 1 || item.Tire.Tire3Pressure < 1 || item.Tire.Tire4Pressure < 1))
                    {
                        Console.WriteLine(item.Model);
                    }
                }
                else
                {
                    if (item.Engine.Power > 250)
                    {
                        Console.WriteLine(item.Model);
                    }
                }
            }
        }
    }
}
