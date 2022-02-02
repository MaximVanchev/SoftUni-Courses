using DefiningClasses;
using System;
using System.Linq;

namespace StartUp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                Family.AddMember(input[0], int.Parse(input[1])); 
            }
            Console.WriteLine($"{Family.GetOldestMember().Name} {Family.GetOldestMember().Age}");
        }
    }
}
