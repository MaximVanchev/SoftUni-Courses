using System;
using System.Collections.Generic;
using System.Linq;


namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                List<double> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
                jaggedArray[row] = new double[input.Count];
                for (int col = 0; col < input.Count; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
            List<string> command = null;
            while ((command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "End")
            {
                if (command[0] == "Add")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if (row < rows && col <= jaggedArray[row].Length && row >= 0 && col >= 0)
                    {
                        jaggedArray[row][col] += value;
                    }
                }
                else
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if (row < rows && row >= 0 && col >= 0 && col <= jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
