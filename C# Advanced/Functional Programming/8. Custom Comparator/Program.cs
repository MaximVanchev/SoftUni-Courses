using System;
using System.Collections.Generic;
using System.Linq;


namespace _8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int> > funcOne = x => 
            {
                x = x.Where(a => a % 2 == 0).OrderBy(x => x).ToList();
                return x;
            };
            Func<List<int>, List<int>> funcTwo = x =>
            {
                x = x.Where(a => a % 2 != 0).OrderBy(x => x).ToList();
                return x;
            };
            Func<List<int>,List<int>, List<int>> func = (a,b) =>
            {
                a.AddRange(b);
                return a;
            };
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine(string.Join(" ",func(funcOne(input),funcTwo(input))));
        }
    }
}
