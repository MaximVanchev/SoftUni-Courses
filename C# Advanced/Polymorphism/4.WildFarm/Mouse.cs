using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }
        public override string Ability()
        {
            return "Squeak";
        }
        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.10;
            }
            else
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
