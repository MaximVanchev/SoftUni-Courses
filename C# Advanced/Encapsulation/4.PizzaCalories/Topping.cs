using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private decimal weight;
        public Topping(string toppingType, decimal weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        public string ToppingType
        {
            get => toppingType;
            set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    toppingType = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public decimal Weight
        {
            get => weight;
            set
            {
                if (value >= 1 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
            }
        }
        public decimal Calories { get => TotalCalories(); }
        private decimal TotalCalories()
        {
            decimal calories = 0;
            if (toppingType.ToLower() == "meat")
            {
                calories = 2 * weight * 1.2m;
            }
            else if (toppingType.ToLower() == "veggies")
            {
                calories = 2 * weight * 0.8m;
            }
            else if (toppingType.ToLower() == "cheese")
            {
                calories = 2 * weight * 1.1m;
            }
            else if (toppingType.ToLower() == "sauce")
            {
                calories = 2 * weight * 0.9m;
            }
            return calories;
        }
    }
}
