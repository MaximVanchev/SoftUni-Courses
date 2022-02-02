using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;
        public Vehicles(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }

        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public virtual void Drive(double distance)
        {
        }
        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
