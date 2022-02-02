using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }
        public override string Ability()
        {
            return "Cluck";
        }
        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.35;
        }
        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
