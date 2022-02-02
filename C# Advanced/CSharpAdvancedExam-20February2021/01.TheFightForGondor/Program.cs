using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Stack<int> plates = new Stack<int>();
            Stack<int> orks = new Stack<int>();
            List<int> platesList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            platesList.Reverse();
            plates = ListToStack(platesList);
            for (int i = 1; i <= waves; i++)
            {
                orks = ListToStack(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                if (i % 3 == 0)
                {
                    plates = AddPlate(plates, int.Parse(Console.ReadLine()));
                }
                while (orks.Count > 0)
                {
                    if (orks.Peek() > plates.Peek())
                    {
                        orks.Push(orks.Pop() - plates.Pop());
                    }
                    else if (orks.Peek() < plates.Peek())
                    {
                        plates.Push(plates.Pop() - orks.Pop());
                    }
                    else
                    {
                        plates.Pop();
                        orks.Pop();
                    }
                    if (plates.Count == 0)
                    {
                        Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                        Console.Write($"Orcs left: ");
                        Console.Write(string.Join(", ",orks));
                        return;
                    }
                }
            }
            Console.WriteLine($"The people successfully repulsed the orc's attack.");
            Console.Write($"Plates left: ");
            Console.Write(string.Join(", ", plates));
        }
        public static Stack<int> ListToStack(List<int> input)
        {
            Stack<int> result = new Stack<int>();
            foreach (var plate in input)
            {
                result.Push(plate);
            }
            return result;
        }
        public static Stack<int> AddPlate(Stack<int> plates,int plate)
        {
            List<int> platesList = new List<int>();
            for (int i = 0; i < plates.Count; i++)
            {
                platesList.Add(plates.Pop());
            }
            platesList.Add(plate);
            platesList.Reverse();
            return ListToStack(platesList);
        }
    }
}
