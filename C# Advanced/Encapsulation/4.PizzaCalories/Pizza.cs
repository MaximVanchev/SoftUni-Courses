using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings = new List<Topping>();
        public Pizza(string name)
        {
            Name = name;
        }
        public string Name 
        { 
            get => name;
            private set
            {
                if (value.Length > 15 || value == "" || value == " ")
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough 
        { 
            set
            {
                dough = value;
            }
        }
        public decimal TotalCalories 
        {
            get => Calories();
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        private decimal Calories()
        {
            decimal calories = 0;
            calories += dough.Calories;
            foreach (var topping in toppings)
            {
                calories += topping.Calories;
            }
            return calories;
        }
    }
}
