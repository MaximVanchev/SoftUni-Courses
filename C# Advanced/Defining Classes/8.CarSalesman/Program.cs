using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                List<string> engine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                if (engine.Count == 1)
                {
                    engines.Add(engine[0], new Engine(engine[0]));
                }
                else if (engine.Count == 2)
                {
                    engines.Add(engine[0], new Engine(engine[0],double.Parse(engine[1])));
                }
                else if (engine.Count == 3)
                {
                    if (int.TryParse(engine[2], out int n))
                    {
                        engines.Add(engine[0], new Engine(engine[0], double.Parse(engine[1]), double.Parse(engine[2]))); 
                    }
                    else
                    {
                        engines.Add(engine[0], new Engine(engine[0], double.Parse(engine[1]), engine[2]));
                    }
                }
                else if (engine.Count == 4)
                {
                    engines.Add(engine[0], new Engine(engine[0], double.Parse(engine[1]), double.Parse(engine[2]),engine[3]));
                }
            }
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                List<string> car = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                if (car.Count == 1)
                {
                    cars.Add(car[0], new Car(car[0]));
                }
                else if (car.Count == 2)
                {
                    cars.Add(car[0], new Car(car[0],engines[car[1]]));
                }
                else if (car.Count == 3)
                {
                    if (int.TryParse(car[2], out int n))
                    {
                        cars.Add(car[0], new Car(car[0], engines[car[1]], double.Parse(car[2])));
                    }
                    else
                    {
                        cars.Add(car[0], new Car(car[0], engines[car[1]], car[2]));
                    }
                }
                else if (car.Count == 4)
                {
                    cars.Add(car[0], new Car(car[0], engines[car[1]], double.Parse(car[2]),car[3]));
                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key}:");
                Console.WriteLine($"  {nullOrNaStrings(item.Value.Engine.Model)}:");
                Console.WriteLine($"    Power: {nullOrNaNumbers(item.Value.Engine.Power)}");
                Console.WriteLine($"    Displacement: {nullOrNaNumbers(item.Value.Engine.Displacement)}");
                Console.WriteLine($"    Efficiency: {nullOrNaStrings(item.Value.Engine.Efficiency)}");
                Console.WriteLine($"  Weight: {nullOrNaNumbers(item.Value.Weight)}");
                Console.WriteLine($"  Color: {nullOrNaStrings(item.Value.Color)}");
            }
        }
        public static string nullOrNaNumbers(double input)
        {
            if (input == 0)
            {
                return $"n/a";
            }
            return input.ToString();
        }
        public static string nullOrNaStrings(string input)
        {
            if (input == null)
            {
                return $"n/a";
            }
            return input;
        }
    }
}
