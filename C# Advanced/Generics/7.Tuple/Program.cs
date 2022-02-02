using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Tuple<string, string> firstTuple = new Tuple<string, string>($"{input[0]} {input[1]}",input[2]);
            input = Console.ReadLine().Split().ToList();
            Tuple<string, int> secondTuple = new Tuple<string, int>(input[0], int.Parse(input[1]));
            input = Console.ReadLine().Split().ToList();
            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
