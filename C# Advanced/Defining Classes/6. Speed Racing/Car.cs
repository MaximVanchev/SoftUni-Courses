using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }
        public bool Move(double travelledDistance)
        {
            if (FuelAmount >= FuelConsumptionPerKilometer * travelledDistance)
            {
                FuelAmount -= FuelConsumptionPerKilometer * travelledDistance;
                TravelledDistance += travelledDistance;
                return true;
            }
            return false;
        }
    }
}
