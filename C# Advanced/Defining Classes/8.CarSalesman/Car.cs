using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CarSalesman
{
    class Car
    {
        public string Model { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public Engine Engine = new Engine();
        public Car(string model)
        {
            Model = model;
        }
        public Car(string model,Engine engine):this(model)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, double weight):this(model,engine)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Model = model;
            Engine = engine;
            Color = color;
        }
        public Car(string model, Engine engine, double weight,string color):this(model,engine,weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
    }
}
