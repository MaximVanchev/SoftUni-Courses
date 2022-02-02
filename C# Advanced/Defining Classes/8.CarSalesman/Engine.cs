using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CarSalesman
{
    class Engine
    {
        public string Model { get; set; }
        public double Power { get; set; }
        public double Displacement { get; set; }
        public string Efficiency { get; set; }
        public Engine()
        {
        }
        public Engine(string model)
        {
            Model = model;
        }
        public Engine(string model,double power):this(model)
        {
            Model = model;
            Power = power;
        }
        public Engine(string model,double power,double displacement):this(model,power)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }
        public Engine(string model, double power,string efficiency):this(model,power)
        {
            Model = model;
            Power = power;
            Efficiency = efficiency;
        }
        public Engine(string model, double power, double displacement, string efficiency):this(model,power,displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
    }
}
