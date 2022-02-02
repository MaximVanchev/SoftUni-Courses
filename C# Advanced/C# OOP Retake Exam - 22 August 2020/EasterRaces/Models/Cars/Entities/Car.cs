using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minimumHorcePower;
        private int maximumHorcePower;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            minimumHorcePower = minHorsePower;
            maximumHorcePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (!(value >= minimumHorcePower && value <= maximumHorcePower))
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters 
        { 
            get => cubicCentimeters;
            private set => cubicCentimeters = value;
        }

        public double CalculateRacePoints(int laps)
        {
            return cubicCentimeters / horsePower * laps;
        }
    }
}
