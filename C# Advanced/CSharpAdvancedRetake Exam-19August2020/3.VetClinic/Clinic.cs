using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public int Capacity { get; set; }
        public Dictionary<string, Pet> Pets = new Dictionary<string, Pet>();
        public int Count = 0;
        public Clinic(int capasity)
        {
            Capacity = capasity;
        }
        public void Add(Pet pet)
        {
            if (Capacity > Pets.Count)
            {
                Pets.Add(pet.Name,pet);
                Count++;
            }
        }
        public bool Remove(string name)
        {
            if (Pets.ContainsKey(name))
            {
                Pets.Remove(name);
                Count--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Pet GetPet(string name,string owner)
        {
            if (Pets.ContainsKey(name))
            {
                if (Pets[name].Owner == owner)
                {
                    return Pets[name];
                }
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in Pets)
            {
                sb.AppendLine($"Pet {pet.Value.Name} with owner: {pet.Value.Owner}");
            }
            return sb.ToString();
        }
        public Pet GetOldestPet()
        {
            Pet result = null;
            int oldestPetAge = Int32.MinValue;
            foreach (var pet in Pets)
            {
                if (pet.Value.Age > oldestPetAge)
                {
                    result = pet.Value;
                    oldestPetAge = pet.Value.Age;
                }
            }
            return result;
        }
    }
}
