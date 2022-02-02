using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + 1.6)
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
        public override void Refuel(double fuel )
        {
            base.Refuel(fuel * 95 / 100);
        }
        public override string ToString()
        {
            return $"Truck: {FuelQuantity:F2}";
        }
    }
}
