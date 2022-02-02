using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }
        public override string Ability()
        {
            return "Hoot Hoot";
        }
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.25;
            }
            else
            {
                throw new ArgumentException($"Owl does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
