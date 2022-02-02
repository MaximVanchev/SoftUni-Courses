using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = ListToStack(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> scarfs = ListToQueue(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List<int> sets = new List<int>();
            while (true)
            {
                if (hats.Count == 0 || scarfs.Count == 0)
                {
                    break;
                }
                if (hats.Peek() > scarfs.Peek())
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
        public static Stack<int> ListToStack(int[] input)
        {
            Stack<int> result = new Stack<int>();
            foreach (var item in input)
            {
                result.Push(item);
            }
            return result;
        }
        public static Queue<int> ListToQueue(int[] input)
        {
            Queue<int> result = new Queue<int>();
            foreach (var item in input)
            {
                result.Enqueue(item);
            }
            return result;
        }
    }
}
