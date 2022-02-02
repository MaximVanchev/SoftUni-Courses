using System;
using System.Linq;
using System.Collections.Generic;


namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> allClothes = new Dictionary<string, Dictionary<string, int>>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(" -> ").ToArray();
                string[] clothes = command[1].Split(",").ToArray();
                if (allClothes.ContainsKey(command[0]))
                {
                    for (int a = 0; a < clothes.Length; a++)
                    {
                        if (allClothes[command[0]].ContainsKey(clothes[a]))
                        {
                            allClothes[command[0]][clothes[a]]++; 
                        }
                        else
                        {
                            allClothes[command[0]].Add(clothes[a], 1);
                        }
                    }
                }
                else
                {
                    allClothes.Add(command[0], new Dictionary<string, int>());
                    for (int a = 0; a < clothes.Length; a++)
                    {
                        if (allClothes[command[0]].ContainsKey(clothes[a]))
                        {
                            allClothes[command[0]][clothes[a]]++;
                        }
                        else
                        {
                            allClothes[command[0]].Add(clothes[a], 1);
                        }
                    }
                }
            }
            string[] itemLookingFor = Console.ReadLine().Split().ToArray();
            foreach (var clothesColor in allClothes)
            {
                Console.WriteLine($"{clothesColor.Key} clothes:");
                foreach (var clothes in clothesColor.Value)
                {
                    if (clothesColor.Key == itemLookingFor[0] && clothes.Key == itemLookingFor[1])
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
