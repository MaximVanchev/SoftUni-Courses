using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secondPlayerCards = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int score = 0;
            while (true)
            {
                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.Add(secondPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCards[0] == secondPlayerCards[0])
                {
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
            }
            if (firstPlayerCards.Count != 0)
            {
                foreach (int i in firstPlayerCards)
                {
                    score += i;
                }
                Console.WriteLine($"First player wins! Sum: {score}");
            }
            else
            {
                foreach (int i in secondPlayerCards)
                {
                    score += i;
                }
                Console.WriteLine($"Second player wins! Sum: {score}");
            }
        }
    }
}
