using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int specialNumber = int.Parse(Console.ReadLine());
            Print(specialNumber, numbers);
        }
        static void Print(int sn, List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x % sn != 0).Reverse()));
        }
    }
}
