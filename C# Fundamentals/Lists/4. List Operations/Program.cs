using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (input[0] != "End")
            {
                string currentDigit = $"{input[0]} {input[1]}";
                if (currentDigit == "Shift left")
                {
                    for (int i = 0; i < Convert.ToInt32(input[2]); i++)
                    {
                        int firstNum = numbers[0];
                        numbers.Add(firstNum);
                        numbers.RemoveAt(0);
                    }
                }
                else if (currentDigit == "Shift right")
                {
                    for (int i = 0; i < Convert.ToInt32(input[2]); i++)
                    {
                        int firstNum = numbers[numbers.Count - 1];
                        numbers.Insert(0,firstNum);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }
                else if (input[0] == "Add")
                {
                    numbers.Add(Convert.ToInt32(input[1]));
                }
                else if (input[0] == "Remove")
                {
                    if (Convert.ToInt32(input[1]) >= 0 && Convert.ToInt32(input[1]) < numbers.Count)
                    {
                        numbers.RemoveAt(Convert.ToInt32(input[1]));
                    }
                    else
                    {
                        Console.WriteLine($"Invalid index");
                    }
                }
                else if (input[0] == "Insert")
                {
                    if (Convert.ToInt32(input[2]) >= 0 && Convert.ToInt32(input[2]) < numbers.Count)
                    {
                        numbers.Insert(Convert.ToInt32(input[2]),Convert.ToInt32(input[1]));
                    }
                    else
                    {
                        Console.WriteLine($"Invalid index");
                    }
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
