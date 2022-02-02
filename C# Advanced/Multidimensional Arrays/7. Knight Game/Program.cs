using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheBoard = int.Parse(Console.ReadLine());
            char[,] chessTable = new char[sizeOfTheBoard, sizeOfTheBoard];
            int maxRemovedKnights = 0;
            int removedKnights = 0;
            for (int row = 0; row < sizeOfTheBoard; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < sizeOfTheBoard; col++)
                {
                    chessTable[row, col] = input[col];
                }
            }
            char[,] chessTableTwo = chessTable;
            for (int row = 0; row < sizeOfTheBoard; row++)
            {
                for (int col = 0; col < sizeOfTheBoard; col++)
                {
                    if (chessTable[row,col] == 'K')
                    {
                        //za nagore proverki
                        if (row - 2 >= 0 && col - 1 >= 0 && row - 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2,col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col - 1] = '0';
                            }
                        }
                        if (row - 2 >= 0 && col + 1 >= 0 && row - 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2,col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col + 1] = '0';
                            }
                        }
                        if (row - 1 >= 0 && col - 2 >= 0 && row - 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1,col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col - 2] = '0';
                            }
                        }
                        if (row - 1 >= 0 && col + 2 >= 0 && row - 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1,col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col + 2] = '0';
                            }
                        }
                        //za nadolo proverki
                        if (row + 2 >= 0 && col - 1 >= 0 && row + 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2,col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col - 1] = '0';
                            }
                        }
                        if (row + 2 >= 0 && col + 1 >= 0 && row + 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2,col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col + 1] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col - 2 >= 0 && row + 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1,col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col - 2] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col + 2 >= 0 && row + 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col + 2] = '0';
                            }
                        }
                        //za nalqvo proverki
                        if (row - 1 >= 0 && col - 2 >= 0 && row - 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1, col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col - 2] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col - 2 >= 0 && row + 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col - 2] = '0';
                            }
                        }
                        if (row + 2 >= 0 && col - 1 >= 0 && row + 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2, col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col - 1] = '0';
                            }
                        }
                        if (row - 2 >= 0 && col - 1 >= 0 && row - 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2, col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col - 1] = '0';
                            }
                        }
                        // za nadqsno proverki
                        if (row - 1 >= 0 && col + 2 >= 0 && row - 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col + 2] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col + 2 >= 0 && row + 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col + 2] = '0';
                            }
                        }
                        if (row - 2 >= 0 && col + 1 >= 0 && row - 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2, col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col + 1] = '0';
                            }
                        }
                        if (row + 2 >= 0 && col + 1 >= 0 && row + 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2, col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col + 1] = '0';
                            }
                        }
                    }
                }
            }
            chessTable = chessTableTwo;
            maxRemovedKnights = removedKnights;
            removedKnights = 0;
            for (int row = sizeOfTheBoard - 1; row <= 0; row++)
            {
                for (int col = sizeOfTheBoard - 1; col <= 0; col++)
                {
                    if (chessTable[row, col] == 'K')
                    {
                        //za nagore proverki
                        if (row - 2 >= 0 && col - 1 >= 0 && row - 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2, col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col - 1] = '0';
                            }
                        }
                        if (row - 2 >= 0 && col + 1 >= 0 && row - 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2, col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col + 1] = '0';
                            }
                        }
                        if (row - 1 >= 0 && col - 2 >= 0 && row - 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1, col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col - 2] = '0';
                            }
                        }
                        if (row - 1 >= 0 && col + 2 >= 0 && row - 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col + 2] = '0';
                            }
                        }
                        //za nadolo proverki
                        if (row + 2 >= 0 && col - 1 >= 0 && row + 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2, col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col - 1] = '0';
                            }
                        }
                        if (row + 2 >= 0 && col + 1 >= 0 && row + 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2, col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col + 1] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col - 2 >= 0 && row + 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col - 2] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col + 2 >= 0 && row + 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col + 2] = '0';
                            }
                        }
                        //za nalqvo proverki
                        if (row - 1 >= 0 && col - 2 >= 0 && row - 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1, col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col - 2] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col - 2 >= 0 && row + 1 < sizeOfTheBoard && col - 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col - 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col - 2] = '0';
                            }
                        }
                        if (row + 2 >= 0 && col - 1 >= 0 && row + 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2, col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col - 1] = '0';
                            }
                        }
                        if (row - 2 >= 0 && col - 1 >= 0 && row - 2 < sizeOfTheBoard && col - 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2, col - 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col - 1] = '0';
                            }
                        }
                        // za nadqsno proverki
                        if (row - 1 >= 0 && col + 2 >= 0 && row - 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 1, col + 2] = '0';
                            }
                        }
                        if (row + 1 >= 0 && col + 2 >= 0 && row + 1 < sizeOfTheBoard && col + 2 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 1, col + 2] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 1, col + 2] = '0';
                            }
                        }
                        if (row - 2 >= 0 && col + 1 >= 0 && row - 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row - 2, col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row - 2, col + 1] = '0';
                            }
                        }
                        if (row + 2 >= 0 && col + 1 >= 0 && row + 2 < sizeOfTheBoard && col + 1 < sizeOfTheBoard)
                        {
                            if (chessTable[row + 2, col + 1] == 'K')
                            {
                                removedKnights++;
                                chessTable[row + 2, col + 1] = '0';
                            }
                        }
                    }
                }
            }
            if (maxRemovedKnights > removedKnights)
            {
                maxRemovedKnights = removedKnights;
            }
            Console.WriteLine(maxRemovedKnights);
        }
    }
}
