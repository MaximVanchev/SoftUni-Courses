using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>();
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            foreach (var item in input)
            {
                clothes.Push(item);
            }
            int currentDigit = 0;
            int racks = 1;
            while (true)
            {
                if (currentDigit + clothes.Peek() < rackCapacity)
                {
                    currentDigit += clothes.Pop();
                    if (clothes.Count == 0)
                    {
                        break;
                    }
                }
                else if (currentDigit + clothes.Peek() == rackCapacity)
                {
                    currentDigit = 0;
                    clothes.Pop();
                    if (clothes.Count > 0)
                    {
                        racks++; 
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    racks++;
                    currentDigit = 0;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
