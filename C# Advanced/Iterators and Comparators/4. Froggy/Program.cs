using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> path = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Lake lake = new Lake(path);
            path = new List<int>();
            foreach (int item in lake)
            {
                path.Add(item);
            }
            Console.WriteLine(string.Join(", ",path));
        }
    }
}
