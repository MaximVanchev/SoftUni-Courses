using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parentheses = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length/2; i++)
            {
                parentheses.Push(input[i]);
            }
            for (int i = input.Length/2; i < input.Length; i++)
            {
                if (parentheses.Peek() == '(')
                {
                    if (input[i] == ')')
                    {
                        parentheses.Pop();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"NO");
                        return;
                    }
                }
                else if (parentheses.Peek() == '[')
                {
                    if (input[i] == ']')
                    {
                        parentheses.Pop();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"NO");
                        return;
                    }
                }
                else if (parentheses.Peek() == '{')
                {
                    if (input[i] == '}')
                    {
                        parentheses.Pop();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"NO");
                        return;
                    }
                }
            }
            Console.WriteLine($"YES");
        }
    }
}
