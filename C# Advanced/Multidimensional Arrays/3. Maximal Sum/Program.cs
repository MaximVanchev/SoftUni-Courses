using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sizeOfTheMatrix = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int rows = sizeOfTheMatrix[0];
            int cols = sizeOfTheMatrix[1];
            int maxSum = Int32.MinValue;
            int[,] maxSumMatrix = new int[3, 3];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                List<int> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sumMatrix = matrix[row, col] +              matrix[row, col + 1] +              matrix[row, col + 2] +      matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                                  //matrix[startRow, startColumn] + matrix[startRow, startColumn + 1] + matrix[startRow, startColumn + 2] + matrix[startRow + 1, startColumn] + matrix[startRow + 1, startColumn + 1] + matrix[startRow + 1, startColumn + 2] + matrix[startRow + 2, startColumn] + matrix[startRow + 2, startColumn + 1] + matrix[startRow + 2, startColumn + 2];
                    if (sumMatrix > maxSum)
                    {
                        maxSum = sumMatrix;
                        int rowMaxSumMatrix = 0;
                        
                        for (int rowMax = row; rowMax < row + 3; rowMax++)
                        {
                            int colMaxSumMatrix = 0;
                            for (int colMax = col; colMax < col + 3; colMax++)
                            {
                                maxSumMatrix[rowMaxSumMatrix, colMaxSumMatrix] = matrix[rowMax, colMax];
                                colMaxSumMatrix++;
                            }
                            rowMaxSumMatrix++;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{maxSumMatrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
