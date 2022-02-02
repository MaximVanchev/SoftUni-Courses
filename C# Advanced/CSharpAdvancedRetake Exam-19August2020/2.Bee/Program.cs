using System;

namespace _2.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int territorySize = int.Parse(Console.ReadLine());
            char[,] territory = new char[territorySize, territorySize];
            int[] beeIndex = null;
            int pollinatedFlowers = 0;
            for (int row = 0; row < territorySize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < territorySize; col++)
                {
                    territory[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beeIndex = new int[2] { row, col };
                    }
                }
            }
            string command = null;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        while (true)
                        {
                            if (beeIndex[0] - 1 >= 0)
                            {
                                if (territory[beeIndex[0] - 1, beeIndex[1]] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                else if (territory[beeIndex[0] - 1, beeIndex[1]] == 'O')
                                {
                                    territory[beeIndex[0], beeIndex[1]] = '.';
                                    territory[beeIndex[0] - 1, beeIndex[1]] = 'B';
                                    beeIndex[0] = beeIndex[0] - 1;
                                    continue;
                                }
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                territory[beeIndex[0] - 1, beeIndex[1]] = 'B';
                                beeIndex[0] = beeIndex[0] - 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"The bee got lost!");
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                Print(territory, pollinatedFlowers, territorySize);
                                return;
                            } 
                        }
                        break;
                    case "down":
                        while (true)
                        {
                            if (beeIndex[0] + 1 < territorySize)
                            {
                                if (territory[beeIndex[0] + 1, beeIndex[1]] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                else if (territory[beeIndex[0] + 1, beeIndex[1]] == 'O')
                                {
                                    territory[beeIndex[0], beeIndex[1]] = '.';
                                    territory[beeIndex[0] + 1, beeIndex[1]] = 'B';
                                    beeIndex[0] = beeIndex[0] + 1;
                                    continue;
                                }
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                territory[beeIndex[0] + 1, beeIndex[1]] = 'B';
                                beeIndex[0] = beeIndex[0] + 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"The bee got lost!");
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                Print(territory, pollinatedFlowers, territorySize);
                                return;
                            } 
                        }
                        break;
                    case "left":
                        while (true)
                        {
                            if (beeIndex[1] - 1 >= 0)
                            {
                                if (territory[beeIndex[0], beeIndex[1] - 1] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                else if (territory[beeIndex[0], beeIndex[1] - 1] == 'O')
                                {                                   
                                    territory[beeIndex[0], beeIndex[1]] = '.';
                                    territory[beeIndex[0], beeIndex[1] - 1] = 'B';
                                    beeIndex[1] = beeIndex[1] - 1;
                                    continue;                                 
                                }
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                territory[beeIndex[0], beeIndex[1] - 1] = 'B';
                                beeIndex[1] = beeIndex[1] - 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"The bee got lost!");
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                Print(territory, pollinatedFlowers, territorySize);
                                return;
                            } 
                        }
                        break;
                    case "right":
                        while (true)
                        {
                            if (beeIndex[1] + 1 < territorySize)
                            {
                                if (territory[beeIndex[0], beeIndex[1] + 1] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                else if (territory[beeIndex[0], beeIndex[1] + 1] == 'O')
                                {
                                    territory[beeIndex[0], beeIndex[1]] = '.';
                                    territory[beeIndex[0], beeIndex[1] + 1] = 'B';
                                    beeIndex[1] = beeIndex[1] + 1;
                                    continue;
                                }
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                territory[beeIndex[0], beeIndex[1] + 1] = 'B';
                                beeIndex[1] = beeIndex[1] + 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"The bee got lost!");
                                territory[beeIndex[0], beeIndex[1]] = '.';
                                Print(territory, pollinatedFlowers, territorySize);
                                return;
                            } 
                        }
                        break;
                }
            }
            Print(territory, pollinatedFlowers, territorySize);
        }
        public static void Print(char[,] territory,int pollinatedFlowers,int territorySize)
        {
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedFlowers} flowers more");
            }
            for (int row = 0; row < territorySize; row++)
            {
                for (int col = 0; col < territorySize; col++)
                {
                    Console.Write(territory[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
