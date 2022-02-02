using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();
            int elementsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < elementsCount; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                for (int a = 0; a < input.Length; a++)
                {
                    elements.Add(input[a]); 
                }
            }
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
