using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int[] powerNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int bombNum = powerNumbers[0];
            int powerNum = powerNumbers[1];
            int sum = 0;
            for (int i = 0; i < listNumbers.Count; i++)
            {
                if (listNumbers[i] == bombNum)
                {
                    for (int k = powerNum; k > 0; k--)
                    {
                        if (i - k >= 0)
                        {
                            listNumbers[i - k] = -1;
                        }
                    }
                    for (int j = 1; j <= powerNum; j++)
                    {
                        if (i + j < listNumbers.Count)
                        {
                            listNumbers[i + j] = -1;
                        }
                    }
                    listNumbers.RemoveAt(i);
                    listNumbers.RemoveAll(p => p == -1);
                }  
            }
            for (int i = 0; i < listNumbers.Count; i++)
            {
                sum += listNumbers[i];
            }
            Console.WriteLine(sum);
        }
    }
}
