using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == ">")
                {
                    for (int j = 1; j < input[i + 1]; j++)
                    {
                        if (input[i + 1] == ">")
                        {
                            input.Reverse(input[i + 2],Convert.ToChar(Convert.ToInt32(input[i + 2]) += input[i + 1] - j));
                        }
                        else
                        {
                            input.RemoveAt(i + 1); 
                        }
                    }
                }
            }
        }
    }
}
