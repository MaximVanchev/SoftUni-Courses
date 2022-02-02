using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        public Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public double TankCapacity { get => tankCapacity; set => tankCapacity = value; }
        public virtual void Drive(double distance)
        {
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (fuel + FuelQuantity > tankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    FuelQuantity += fuel;
                } 
            }
            else
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}
