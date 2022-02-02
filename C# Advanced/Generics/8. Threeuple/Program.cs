using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            if (!(input.Count > 4))
            {
                Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>($"{input[0]} {input[1]}", input[2],input[3]);
                Console.WriteLine(firstThreeuple.ToString());
            }
            else
            {
                Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>($"{input[0]} {input[1]}", input[2],$"{input[3]} {input[4]}");
                Console.WriteLine(firstThreeuple.ToString());
            }
            input = Console.ReadLine().Split().ToList();
            if (input[2] == "drunk")
            {
                Threeuple<string, int, string> secondThreeuple = new Threeuple<string, int, string>(input[0], int.Parse(input[1]), "True");
                Console.WriteLine(secondThreeuple.ToString());
            }
            else
            {
                Threeuple<string, int, string> secondThreeuple = new Threeuple<string, int, string>(input[0], int.Parse(input[1]), "False");
                Console.WriteLine(secondThreeuple.ToString());
            }
            input = Console.ReadLine().Split().ToList();
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(thirdThreeuple.ToString());
        }
    }
}
