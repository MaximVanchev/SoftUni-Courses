using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sizeOfTheMatrix = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int rows = sizeOfTheMatrix[0];
            int cols = sizeOfTheMatrix[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                List<string> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            List<string> command = null;
            while ((command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList())[0] != "END")
            {
                if (command.Count == 5)
                {
                    if (command[0] == "swap")
                    {
                        if (int.Parse(command[1]) < rows && int.Parse(command[2]) < cols && int.Parse(command[3]) < rows && int.Parse(command[4]) <= cols && int.Parse(command[1]) >= 0 && int.Parse(command[2]) >= 0 && int.Parse(command[3]) >= 0 && int.Parse(command[4]) >= 0)
                        {
                            string currentDigit = matrix[int.Parse(command[1]), int.Parse(command[2])];
                            matrix[int.Parse(command[1]), int.Parse(command[2])] = matrix[int.Parse(command[3]), int.Parse(command[4])];
                            matrix[int.Parse(command[3]), int.Parse(command[4])] = currentDigit;
                            for (int row = 0; row < rows; row++)
                            {
                                for (int col = 0; col < cols; col++)
                                {
                                    Console.Write($"{matrix[row, col]} ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    } 
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }
            }
        }
    }
}
