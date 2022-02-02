using System;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = 0;
            char[,] gameField = null;
            int[] marioCordinates = new int[2];
            for (int row = 0; row < rowsCount; row++)
            {
                string rowNums = Console.ReadLine();
                if (row == 0)
                {
                    colsCount = rowNums.Length;
                    gameField = new char[rowsCount, colsCount];
                }
                for (int col = 0; col < colsCount; col++)
                {
                    gameField[row, col] = rowNums[col];
                    if (gameField[row, col] == 'M')
                    {
                        marioCordinates[0] = row;
                        marioCordinates[1] = col;
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                gameField[int.Parse(command[1]), int.Parse(command[2])] = 'B';
                int[] neededCordinates = marioCordinates.ToArray();
                if (command[0] == "W")
                {
                    neededCordinates[0] -= 1;
                }
                else if (command[0] == "S")
                {
                    neededCordinates[0] += 1;
                }
                else if (command[0] == "A")
                {
                    neededCordinates[1] -= 1;
                }
                else if (command[0] == "D")
                {
                    neededCordinates[1] += 1;
                }
                try
                {                    
                    if (gameField[neededCordinates[0], neededCordinates[1]] == 'B')
                    {
                        marioLives -= 3;
                    }
                    else if (gameField[neededCordinates[0], neededCordinates[1]] == '-')
                    {
                        marioLives -= 1;
                    }
                    else if (gameField[neededCordinates[0], neededCordinates[1]] == 'P')
                    {
                        marioLives -= 1;
                        gameField[neededCordinates[0], neededCordinates[1]] = '-';
                        gameField[marioCordinates[0], marioCordinates[1]] = '-';
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                        break;
                    }                
                    gameField[neededCordinates[0], neededCordinates[1]] = 'M';
                    gameField[marioCordinates[0], marioCordinates[1]] = '-';
                    marioCordinates = neededCordinates;
                    if (marioLives <= 0)
                    {
                        gameField[marioCordinates[0], marioCordinates[1]] = 'X';
                        Console.WriteLine($"Mario died at {marioCordinates[0]};{marioCordinates[1]}.");
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    marioLives--;
                }
                if (marioLives <= 0)
                {
                    gameField[marioCordinates[0], marioCordinates[1]] = 'X';
                    Console.WriteLine($"Mario died at {marioCordinates[0]};{marioCordinates[1]}.");
                    break;
                }
            }
            Console.WriteLine(FinalGameString(gameField, rowsCount, colsCount));
        }
        public static string FinalGameString(char[,] game, int rows, int cols)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sb.Append(game[row, col]);
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
