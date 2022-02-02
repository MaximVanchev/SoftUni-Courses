using System;
using System.Collections.Generic;
using System.Linq;


namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLenght = int.Parse(Console.ReadLine());
            Func<string, bool> lenghtFunc = x => x.Length <= namesLenght;
            List<string> names = Console.ReadLine().Split().ToList();
            Print(lenghtFunc, names);
        }
        static void Print(Func<string, bool> func,List<string> names)
        {
            foreach (var item in names)
            {
                if (func(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }   
}
