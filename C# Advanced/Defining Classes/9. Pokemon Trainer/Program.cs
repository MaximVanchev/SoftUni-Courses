using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            List<string> command = null;
            while ((command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "Tournament")
            {
                if (trainers.ContainsKey(command[0]))
                {
                    trainers[command[0]].AddPokemon(command[1], command[2], int.Parse(command[3]));
                }
                else
                {
                    trainers.Add(command[0], new Trainer(command[0], command[1], command[2], int.Parse(command[3])));
                }
            }
            while ((command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "End")
            {
                if (command[0] == "Fire")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        if (trainer.FirePokemons > 0)
                        {
                            trainer.BadgesCount++;
                        }
                        else
                        {
                            if (trainer.Pokemons.Count > 0)
                            {
                                foreach (var pokemon in trainer.Pokemons)
                                {
                                    pokemon.Health -= 10;
                                }
                                for (int i = 0; i < trainer.Pokemons.Count; i++)
                                {
                                    if (trainer.Pokemons[i].Health < 1)
                                    {
                                        trainer.RemovePokemon(trainer.Pokemons[i]);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (command[0] == "Water")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        if (trainer.WaterPokemons > 0)
                        {
                            trainer.BadgesCount++;
                        }
                        else
                        {
                            if (trainer.Pokemons.Count > 0)
                            {
                                foreach (var pokemon in trainer.Pokemons)
                                {
                                    pokemon.Health -= 10;
                                }
                                for (int i = 0; i < trainer.Pokemons.Count; i++)
                                {
                                    if (trainer.Pokemons[i].Health < 1)
                                    {
                                        trainer.RemovePokemon(trainer.Pokemons[i]);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (command[0] == "Electricity")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        if (trainer.ElectricityPokemons > 0)
                        {
                            trainer.BadgesCount++;
                        }
                        else
                        {
                            if (trainer.Pokemons.Count > 0)
                            {
                                foreach (var pokemon in trainer.Pokemons)
                                {
                                    pokemon.Health -= 10;                                   
                                }
                                for (int i = 0; i < trainer.Pokemons.Count; i++)
                                {
                                    if (trainer.Pokemons[i].Health < 1)
                                    {
                                        trainer.RemovePokemon(trainer.Pokemons[i]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (var trainer in trainers.Values.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
