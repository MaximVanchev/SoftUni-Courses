using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int> addFunc = a => a + 1;
            Func<int, int> multiplyFunc = a => a * 2;
            Func<int, int> subtactFunc = a => a - 1;
            Action<List<int>> printFunc = x => Console.WriteLine(string.Join(" ",x));
            string command = null; 
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => addFunc(x)).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => multiplyFunc(x)).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => subtactFunc(x)).ToList();
                        break;
                    case "print":
                        printFunc(numbers);
                        break;
                }
            }
        }
    }
}
