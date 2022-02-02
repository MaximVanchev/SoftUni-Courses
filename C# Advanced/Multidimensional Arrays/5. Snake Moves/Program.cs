using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sizeOfTheMatrix = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<char> snakeQueue = new Queue<char>();
            int rows = sizeOfTheMatrix[0];
            int cols = sizeOfTheMatrix[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            for (int i = 0; i < snake.Length; i++)
            {
                snakeQueue.Enqueue(snake[i]);
            }
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakeQueue.Peek();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    } 
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeQueue.Peek();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

        }
    }
}
