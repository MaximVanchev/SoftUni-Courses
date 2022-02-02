using System;
using System.Collections.Generic;

namespace _5.GenericCountMethodStrings
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
            string currentDigit = Console.ReadLine();
            Console.WriteLine(CompareStrings(list,currentDigit));
        }
        public static int CompareStrings<T>(List<T> list, T currentDigit)
            where T: IComparable<T>
        {
            int result = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(currentDigit) > 0)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
