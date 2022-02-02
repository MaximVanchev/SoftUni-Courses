using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;
        public Aquarium(string name, int capacity)
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
            Name = name;
            Capacity = capacity;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity { get => capacity; private set => capacity = value; }

        public int Comfort
        {
            get => Decorations.Select(d => d.Comfort).Sum();
        }

        public ICollection<IDecoration> Decorations { get => decorations; private set => decorations = value.ToList(); }

        public ICollection<IFish> Fish { get => fishes; private set => fishes = value.ToList(); }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishes.Count == capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            fishes.Add(fish);
        }

        public void Feed()
        {
            fishes.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {
            string fishString = "none";
            if (fishes.Count > 0)
            {
                fishString = string.Join(", ",fishes.Select(x => x.Name));
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({GetType().Name}):");
            sb.AppendLine($"Fish: {fishString}");
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.Append($"Comfort: {Comfort}");
            return sb.ToString();
        }

        public bool RemoveFish(IFish fish)
        {
            if (fishes.Any(x => x.Name == fish.Name))
            {
                fishes.Remove(fish);
                return true;
            }
            return false;
        }
    }
}
