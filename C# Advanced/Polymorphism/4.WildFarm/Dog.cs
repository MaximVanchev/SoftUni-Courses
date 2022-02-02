using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }
        public override string Ability()
        {
            return "Woof!";
        }
        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.40;
            }
            else
            {
                throw new ArgumentException($"Dog does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
