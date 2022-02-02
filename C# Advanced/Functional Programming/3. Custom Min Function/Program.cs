using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> newLineAction = x => Console.WriteLine(x.Min());
            newLineAction(Console.ReadLine().Split().Select(int.Parse).ToArray());
        }
    }
}
