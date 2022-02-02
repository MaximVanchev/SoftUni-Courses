using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquare = int.Parse(Console.ReadLine());
            int[,] square = new int[sizeOfTheSquare, sizeOfTheSquare];
            int sumOfLeftDiagonal = 0;
            int sumOfRightDiagonal = 0;
            for (int row = 0; row < sizeOfTheSquare; row++)
            {
                List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
                for (int col = 0; col < sizeOfTheSquare; col++)
                {
                    square[row, col] = input[col];
                }
            }
            for (int row = 0; row < sizeOfTheSquare; row++)
            {
                sumOfLeftDiagonal += square[row, row];
            }
            int currentDigit = sizeOfTheSquare - 1;
            for (int row = 0; row < sizeOfTheSquare; row++)
            {
                sumOfRightDiagonal += square[row, currentDigit];
                currentDigit -= 1;
            }
            if (sumOfLeftDiagonal > sumOfRightDiagonal)
            {
                Console.WriteLine(sumOfLeftDiagonal - sumOfRightDiagonal);
            }
            else if (sumOfLeftDiagonal < sumOfRightDiagonal)
            {
                Console.WriteLine(sumOfRightDiagonal - sumOfLeftDiagonal);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
