using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicles> vehicles = new List<Vehicles>();
            string input = null;
            int trucksCount = 0;
            double trucksHorsepower = 0;
            double carsHorsepower = 0;
            int carsCount = 0;
            double trucksAverageHorsepower = 0;
            double carsAverageHorsepower = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> vehicle = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (vehicle[0] == "truck")
                {
                    trucksCount++;
                    trucksHorsepower += Convert.ToInt32(vehicle[3]);
                }
                else
                {
                    carsCount++;
                    carsHorsepower += Convert.ToInt32(vehicle[3]);
                }
                Vehicles newVehicle = new Vehicles(vehicle[0],vehicle[1],vehicle[2],Convert.ToDouble(vehicle[3]));
                vehicles.Add(newVehicle);
                if (carsCount+trucksCount >= 50)
                {
                    break;
                }
            }
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Console.WriteLine(vehicles.FirstOrDefault(x => x.Model == input));
            }
            if (carsCount == 0)
            {
            }
            else
            {
                carsAverageHorsepower = carsHorsepower / carsCount; 
            }
            if (trucksCount == 0)
            {
            }
            else
            {
                trucksAverageHorsepower = trucksHorsepower / trucksCount; 
            }
            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsepower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsepower:F2}.");
        }
    }
    public class Vehicles
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
        public Vehicles(string type,string model,string color,double horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            _ = sb.AppendLine($"Type: {Type.First().ToString().ToUpper() + String.Join("", Type.Skip(1))}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");
            return sb.ToString().TrimEnd();
        }
    }
}
