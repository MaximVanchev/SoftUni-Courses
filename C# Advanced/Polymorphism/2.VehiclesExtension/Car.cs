using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : Vehicles
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 0.9, tankCapacity)
        {

        }
        public override void Drive(double distance)
        {
            if ((FuelConsumption * distance) <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption * distance);
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
        public override string ToString()
        {
            return $"Car: {FuelQuantity:F2}";
        }
    }
}
