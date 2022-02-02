using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string doughType;
        private string bakingTechnique;
        private decimal weight;
        public Dough(string doughType,string bakingTechnique,decimal weight)
        {
            DoughType = doughType;
            BakingTechnique = bakingTechnique;
            Weight = weight;          
        }
        public string DoughType 
        { 
            get => doughType;
            set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    doughType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public decimal Weight 
        { 
            get => weight;
            set
            {
                if (value >= 1 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
        public decimal Calories { get => TotalCalories();}
        private decimal TotalCalories()
        {
            decimal calories = 0;
            if (doughType.ToLower() == "white")
            {
                if (bakingTechnique.ToLower() == "crispy")
                {
                    calories = 2 * weight * 1.5m * 0.9m;
                }
                else if (bakingTechnique.ToLower() == "chewy")
                {
                    calories = 2 * weight * 1.5m * 1.1m;
                }
                else if (bakingTechnique.ToLower() == "homemade")
                {
                    calories = 2 * weight * 1.5m * 1.0m;
                }
            }
            else if (doughType.ToLower() == "wholegrain")
            {
                if (bakingTechnique.ToLower() == "crispy")
                {
                    calories = 2 * weight * 1.0m * 0.9m;
                }
                else if (bakingTechnique.ToLower() == "chewy")
                {
                    calories = 2 * weight * 1.0m * 1.1m;
                }
                else if (bakingTechnique.ToLower() == "homemade")
                {
                    calories = 2 * weight * 1.0m * 1.0m;
                }
            }
            return calories;
        }
    }
}
