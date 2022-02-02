using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get => name; private set => name = value; }
        public double Weight { get => weight; protected set => weight = value; }
        public int FoodEaten { get => foodEaten; protected set => foodEaten = value; }
        public abstract string Ability();
        public abstract void Eat(Food food);
    }
}
