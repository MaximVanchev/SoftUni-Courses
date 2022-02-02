using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicles
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }
        public override void Drive(double distance)
        {
            FuelConsumption += 1.4;
            DriveEmpty(distance);
        }
        public void DriveEmpty(double distance)
        {
            if ((FuelConsumption * distance) <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption * distance);
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public override string ToString()
        {
            return $"Bus: {FuelQuantity:F2}";
        }
    }
}
