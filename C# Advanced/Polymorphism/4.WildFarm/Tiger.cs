using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }
        public override string Ability()
        {
            return "ROAR!!!";
        }
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Tiger does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
