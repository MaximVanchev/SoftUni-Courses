using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Pokemon_Trainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int BadgesCount = 0;
        public List<Pokemon> Pokemons = new List<Pokemon>();
        public int FirePokemons = 0;
        public int WaterPokemons = 0;
        public int ElectricityPokemons = 0;
        public Trainer(string name,string pokemonName,string pokemonElement,int pokemonHealth)
        {
            Name = name;
            AddPokemon(pokemonName, pokemonElement, pokemonHealth);
        }
        public void AddPokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            if (pokemonElement == "Fire")
            {
                FirePokemons++;
            }
            else if (pokemonElement == "Water")
            {
                WaterPokemons++;
            }
            else if (pokemonElement == "Electricity")
            {
                ElectricityPokemons++;
            }
        }
        public void RemovePokemon(Pokemon pokemon)
        {
            Pokemons.Remove(pokemon);
            if (pokemon.Element == "Fire")
            {
                FirePokemons--;
            }
            else if (pokemon.Element == "Water")
            {
                WaterPokemons--;
            }
            else if (pokemon.Element == "Electricity")
            {
                ElectricityPokemons--;
            }
        }
    }
}
