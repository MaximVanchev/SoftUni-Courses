using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine = new Engine();
        public Cargo Cargo = new Cargo();
        public Tire Tire = new Tire();

        public Car(string model,double speed, double power, double weight, string type, double tire1Pressure, double tire1Age, double tire2Pressure, double tire2Age, double tire3Pressure, double tire3Age, double tire4Pressure, double tire4Age)
        {
            Model = model;
            Engine.Speed = speed;
            Engine.Power = power;
            Cargo.Weight = weight;
            Cargo.Type = type;
            Tire.Tire1Pressure = tire1Pressure;
            Tire.Tire1Age = tire1Age;
            Tire.Tire2Pressure = tire2Pressure;
            Tire.Tire2Age = tire2Age;
            Tire.Tire3Pressure = tire3Pressure;
            Tire.Tire3Age = tire3Age;
            Tire.Tire4Pressure = tire4Pressure;
            Tire.Tire4Age = tire4Age;
        }
    }
}
