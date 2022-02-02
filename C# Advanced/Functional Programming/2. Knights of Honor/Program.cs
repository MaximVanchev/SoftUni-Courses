using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> newLineAction = x => Console.WriteLine($"Sir {x}");
            string[] input = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                newLineAction(input[i]); 
            }
        }
    }
}
