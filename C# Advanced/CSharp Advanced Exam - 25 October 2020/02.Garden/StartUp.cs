using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garden
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] gardenDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] garden = new int[gardenDimensions[0], gardenDimensions[1]];
            string input = null;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] flower = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                try
                {
                    garden[flower[0], flower[1]] = 0;
                    for (int row = 0; row < gardenDimensions[0]; row++)
                    {
                        garden[row, flower[1]] += 1;
                    }
                    for (int col = 0; col < gardenDimensions[1]; col++)
                    {
                        if (col == flower[1])
                        {
                            continue;
                        }
                        garden[flower[0], col] += 1;
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
            }
            Console.WriteLine(FinalStringGarden(garden, gardenDimensions));
        }
        public static string FinalStringGarden(int[,] garden, int[] gardenDimensions)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < gardenDimensions[0]; row++)
            {
                for (int col = 0; col < gardenDimensions[1]; col++)
                {
                    sb.Append($"{garden[row, col]} ");
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
