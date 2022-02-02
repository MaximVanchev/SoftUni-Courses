using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {

        }
        public override void Drive(double distance)
        {
            if ((FuelConsumption * distance) <= FuelQuantity)
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }
        public override void Refuel(double fuel)
        {
            double currentDigit = fuel * 95 / 100;
            if (fuel > 0)
            {
                if (currentDigit + FuelQuantity > TankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    FuelQuantity += currentDigit;
                }
            }
            else
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
        public override string ToString()
        {
            return $"Truck: {FuelQuantity:F2}";
        }
    }
}
