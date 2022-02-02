using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Legendary_Farming
{
    class Program
    {
        public object StrngBiulder { get; private set; }

        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> specialMaterials = new Dictionary<string, int>();
            specialMaterials.Add("shards", 0);
            specialMaterials.Add("fragments", 0);
            specialMaterials.Add("motes", 0);
            bool wh = true;
            while (wh)
            {
                List<string> input = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                while (input.Count != 0)
                {
                    if (materials.ContainsKey(input[1]))
                    {
                        materials[input[1]] += Convert.ToInt32(input[0]);
                    }
                    else
                    {
                        if (input[1] == "shards")
                        {
                            specialMaterials[input[1]] += Convert.ToInt32(input[0]);
                        }
                        else if (input[1] == "fragments")
                        {
                            specialMaterials[input[1]] += Convert.ToInt32(input[0]);
                        }
                        else if (input[1] == "motes")
                        {
                            specialMaterials[input[1]] += Convert.ToInt32(input[0]);
                        }
                        else
                        {
                            materials.Add(input[1], Convert.ToInt32(input[0])); 
                        }
                    }
                    input.RemoveAt(0);
                    input.RemoveAt(0);
                    if (specialMaterials["shards"] >= 250 || specialMaterials["fragments"] >= 250 || specialMaterials["motes"] >= 250)
                    {
                        wh = false;
                        break;
                    }

                }
            }
            if (specialMaterials["shards"] >= 250)
            {
                specialMaterials["shards"] -= 250;
                Console.WriteLine($"Shadowmourne obtained!");
            }
            else if (specialMaterials["fragments"] >= 250)
            {
                specialMaterials["fragments"] -= 250;
                Console.WriteLine($"Valanyr obtained!");

            }
            else if (specialMaterials["motes"] >= 250)
            {
                specialMaterials["motes"] -= 250;
                Console.WriteLine($"Dragonwrath obtained!");
            }
            foreach (var item in specialMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Key == "shards")
                {
                    Console.WriteLine($"shards: {item.Value}");
                }
                else if (item.Key == "fragments")
                {
                    Console.WriteLine($"fragments: {item.Value}");
                }
                else if (item.Key == "motes")
                {
                    Console.WriteLine($"motes: {item.Value}");
                }
            }
            foreach (var item in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
