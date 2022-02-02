using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            int[] setsLenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int setOneLenght = setsLenghts[0];
            int setTwoLenght = setsLenghts[1];
            for (int i = 0; i < setOneLenght; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setOne.Add(num);
            }
            for (int i = 0; i < setTwoLenght; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setTwo.Add(num);
            }
            foreach (var item in setOne)
            {
                if (setTwo.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
