using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicles
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity,fuelConsumption + 0.9)
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
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
        }
        public override string ToString()
        {
            return $"Car: {FuelQuantity:F2}";
        }
    }
}
