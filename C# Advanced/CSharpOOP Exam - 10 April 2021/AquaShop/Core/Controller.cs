using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
                return "Successfully added FreshwaterAquarium.";
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
                return "Successfully added SaltwaterAquarium.";
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
                return "Successfully added Ornament.";
            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
                return "Successfully added Plant.";
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    return "Water not suitable.";
                }
                aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    return "Water not suitable.";
                }
                aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            throw new InvalidOperationException("Invalid fish type.");
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal result = aquarium.Fish.Select(x => x.Price).Sum() + aquarium.Decorations.Select(x => x.Price).Sum();
            return $"The value of Aquarium {aquariumName} is {result:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (!decorations.Models.Any(x => x.GetType().Name == decorationType))
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decorations.FindByType(decorationType));
            decorations.Remove(decorations.FindByType(decorationType));
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        private string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
