using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var item in input)
            {
                orders.Enqueue(item);
            }
            Console.WriteLine(orders.Max());
            while (true)
            {
                if (food > 0)
                {
                    if (food >= orders.Peek())
                    {
                        food -= orders.Dequeue();
                    }
                    else
                    {
                        Console.Write($"Orders left: ");
                        Console.Write(string.Join(" ", orders));
                        return;
                    }
                }
                else
                {
                    Console.Write($"Orders left: ");
                    Console.Write(string.Join(" ", orders));
                    return;
                }
                if (orders.Count == 0)
                {
                    Console.WriteLine($"Orders complete");
                    return;
                }
            }
        }
    }
}
