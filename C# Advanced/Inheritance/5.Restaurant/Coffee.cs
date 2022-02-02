using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {
            Milliliters = 50;
            Price = 3.50m;
        }
        public double Caffeine { get; set; }
    }
}
