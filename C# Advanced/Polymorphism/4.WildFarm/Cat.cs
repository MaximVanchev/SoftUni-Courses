using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }
        public override string Ability()
        {
            return "Meow";
        }
        public override void Eat(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.30;
            }
            else
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
