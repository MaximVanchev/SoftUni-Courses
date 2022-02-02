using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> newLineAction = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            newLineAction(Console.ReadLine().Split());
        }
    }
}
