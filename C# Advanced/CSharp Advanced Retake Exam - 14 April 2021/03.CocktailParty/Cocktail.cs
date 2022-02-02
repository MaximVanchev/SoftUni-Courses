using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get => ingredients.Select(x => x.Alcohol).Sum(); }
        public void Add(Ingredient ingredient)
        {
            if (ingredients.FirstOrDefault(x => x.Name == ingredient.Name) != default || ingredients.Count == Capacity)
            {
                return;
            }
            ingredients.Add(ingredient);
        }
        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredient == default)
            {
                return false;
            }
            ingredients.Remove(ingredient);
            return true;
        }
        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredient == default)
            {
                return null;
            }
            return ingredient;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.FirstOrDefault(y => y.Alcohol == ingredients.Select(x => x.Alcohol).Max());
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
