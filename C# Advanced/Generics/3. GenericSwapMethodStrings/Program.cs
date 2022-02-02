using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                list.Add(Console.ReadLine());
            }
            List<int> indexes = Console.ReadLine().Split().Select(int.Parse).ToList();
            list = SwapIndexes(list, indexes[0], indexes[1]);
            Print(list);
        }
        public static List<T> SwapIndexes<T>(List<T> list,int indexOne,int indexTwo)
        {
            T currentDigit = list[indexOne];
            list[indexOne] = list[indexTwo];
            list[indexTwo] = currentDigit;
            return list;
        }
        public static void Print<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{typeof(T)}: {item}");
            }
        }
    }
}
