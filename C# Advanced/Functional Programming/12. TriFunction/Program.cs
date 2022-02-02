using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, int, bool> func = (a, b) =>
            {
                int score = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    score += Convert.ToInt32(a[i]);
                }
                if (score >= b)
                {
                    return true;
                }
                return false;
            };
            foreach (var item in names)
            {
                if (func(item,num))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
