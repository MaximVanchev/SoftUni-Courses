using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new string[] { ", "," " },StringSplitOptions.RemoveEmptyEntries).ToList();
            input.RemoveAt(0);
            Stack<string> stack = new Stack<string>(input);
            List<string> command = null;
            while ((command = Console.ReadLine().Split().ToList())[0] != "END")
            {
                if (command[0] == "Pop")
                {
                    stack.Pop();
                }
                else if (command[0] == "Push")
                {
                    stack.Push(command[1]);
                }
            }
            foreach (var item in stack.Reverse())
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack.Reverse())
            {
                Console.WriteLine(item);
            }
        }
    }
}
