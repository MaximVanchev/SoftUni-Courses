using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heros = new List<BaseHero>();
            int herosCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < herosCount; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == "Druid")
                {
                    Druid druid = new Druid(name);
                    heros.Add(druid);
                }
                else if (type == "Paladin")
                {
                    Paladin paladin = new Paladin(name);
                    heros.Add(paladin);
                }
                else if (type == "Rogue")
                {
                    Rogue rogue = new Rogue(name);
                    heros.Add(rogue);
                }
                else if (type == "Warrior")
                {
                    Warrior warrior = new Warrior(name);
                    heros.Add(warrior);
                }
                else
                {
                    i--;
                    Console.WriteLine("Invalid hero!");
                }
            }
            int totalPower = 0;
            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }
            int BossHealth = int.Parse(Console.ReadLine());
            if (BossHealth <= totalPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
