using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sizeOfTheMatrix = Console.ReadLine().Split().Select(int.Parse).ToList();
            int squaresCount = 0;
            int rows = sizeOfTheMatrix[0];
            int cols = sizeOfTheMatrix[1];
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = Convert.ToChar(input[col].ToLower());
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row,col] == matrix[row,col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squaresCount++;
                    }
                }
            }
            Console.WriteLine(squaresCount);
        }
    }
}
