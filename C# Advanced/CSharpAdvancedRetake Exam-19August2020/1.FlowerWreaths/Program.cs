using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int>[] flowers = new Queue<int>[2] { new Queue<int>(),new Queue<int>()};
            int wreaths = 0;
            int leftFlowers = 0;
            int[] lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            foreach (var item in lilies)
            {
                flowers[0].Enqueue(item);
            }
            foreach (var item in roses)
            {
                flowers[1].Enqueue(item);
            }
            if (lilies.Length <= roses.Length)
            {
                for (int i = 0; i < lilies.Length; i++)
                {
                    if (flowers[0].Peek() + flowers[1].Peek() == 15)
                    {
                        flowers[0].Dequeue();
                        flowers[1].Dequeue();
                        wreaths++;
                    }
                    else if (flowers[0].Peek() + flowers[1].Peek() > 15)
                    {
                        i--;
                        flowers[0].Enqueue(flowers[0].Dequeue() - 2);
                        flowers[1].Enqueue(flowers[1].Dequeue());
                    }
                    else if (flowers[0].Peek() + flowers[1].Peek() < 15)
                    {
                        leftFlowers += flowers[0].Dequeue() + flowers[1].Dequeue();
                    }
                } 
            }
            else
            {
                for (int i = 0; i < roses.Length; i++)
                {
                    if (flowers[0].Peek() + flowers[1].Peek() == 15)
                    {
                        flowers[0].Dequeue();
                        flowers[1].Dequeue();
                        wreaths++;
                    }
                    else if (flowers[0].Peek() + flowers[1].Peek() > 15)
                    {
                        i--;
                        flowers[0].Enqueue(flowers[0].Dequeue() - 2);
                        flowers[1].Enqueue(flowers[1].Dequeue());
                    }
                    else if (flowers[0].Peek() + flowers[1].Peek() < 15)
                    {
                        leftFlowers += flowers[0].Dequeue() + flowers[1].Dequeue();
                    }
                }
            }
            wreaths += leftFlowers / 15;
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }
        }
    }
}
