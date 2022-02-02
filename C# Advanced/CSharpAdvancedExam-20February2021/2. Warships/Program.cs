using System;
using System.Linq;

namespace _2._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int playerOneShips = 0;
            int playerTwoShips = 0;
            int playerOneDestroyedShips = 0;
            int playerTwoDestroyedShips = 0;
            string[] playersCommands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[,] field = new char[fieldSize, fieldSize];
            for (int row = 0; row < fieldSize; row++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < fieldSize; col++)
                {
                    if (line[col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (line[col] == '>')
                    {
                        playerTwoShips++;
                    }
                    field[row, col] = line[col];
                }
            }
            for (int i = 0; i < playersCommands.Length; i++)
            {
                int[] command = playersCommands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (command[0] >= 0 && command[0] < fieldSize && command[1] >= 0 && command[1] < fieldSize)
                {
                    if (field[command[0], command[1]] == '#')
                    {
                        field[command[0], command[1]] = 'X';
                        if (command[1] - 1 >= 0)
                        {
                            if (field[command[0], command[1] - 1] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0], command[1] - 1] = 'X';
                            }
                            else if (field[command[0], command[1] - 1] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0], command[1] - 1] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[1] - 1 >= 0 && command[0] - 1 >= 0)
                        {
                            if (field[command[0] - 1, command[1] - 1] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0] - 1, command[1] - 1] = 'X';
                            }
                            else if (field[command[0] - 1, command[1] - 1] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0] - 1, command[1] - 1] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[0] - 1 >= 0)
                        {
                            if (field[command[0] - 1, command[1]] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0] - 1, command[1]] = 'X';
                            }
                            else if (field[command[0] - 1, command[1]] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0] - 1, command[1]] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[0] - 1 >= 0 && command[1] + 1 < fieldSize)
                        {
                            if (field[command[0] - 1, command[1] + 1] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0] - 1, command[1] + 1] = 'X';
                            }
                            else if (field[command[0] - 1, command[1] + 1] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0] - 1, command[1] + 1] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[1] + 1 < fieldSize)
                        {
                            if (field[command[0], command[1] + 1] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0], command[1] + 1] = 'X';
                            }
                            else if (field[command[0], command[1] + 1] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0], command[1] + 1] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[1] + 1 < fieldSize && command[0] + 1 < fieldSize)
                        {
                            if (field[command[0] + 1, command[1] + 1] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0] + 1, command[1] + 1] = 'X';
                            }
                            else if (field[command[0] + 1, command[1] + 1] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0] + 1, command[1] + 1] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[0] + 1 < fieldSize)
                        {
                            if (field[command[0] + 1, command[1]] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0] + 1, command[1]] = 'X';
                            }
                            else if (field[command[0] + 1, command[1]] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0] + 1, command[1]] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                        if (command[0] + 1 < fieldSize && command[1] - 1 >= 0)
                        {
                            if (field[command[0] + 1, command[1] - 1] == '>')
                            {
                                playerTwoShips--;
                                playerTwoDestroyedShips++;
                                field[command[0] + 1, command[1] - 1] = 'X';
                            }
                            else if (field[command[0] + 1, command[1] - 1] == '<')
                            {
                                playerOneShips--;
                                playerOneDestroyedShips++;
                                field[command[0] + 1, command[1] - 1] = 'X';
                            }
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                            else if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            }
                        }
                    }
                    else if (i % 2 == 0)
                    {
                        if (field[command[0],command[1]] == '>')
                        {
                            playerTwoShips--;
                            playerTwoDestroyedShips++;
                            field[command[0], command[1]] = 'X';
                            if (playerTwoShips < 1)
                            {
                                Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            } 
                        }
                    }
                    else if (i % 2 != 0)
                    {
                        if (field[command[0],command[1]] == '<')
                        {
                            playerOneShips--;
                            playerOneDestroyedShips++;
                            field[command[0], command[1]] = 'X';
                            if (playerOneShips < 1)
                            {
                                Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                                return;
                            } 
                        }
                    }
                }
            }
            Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
        }
    }
}
