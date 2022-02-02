using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = ListToStack(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            Queue<int> threads = ListToQueue(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            int taskNum = int.Parse(Console.ReadLine());
            while (true)
            {
                if (tasks.Peek() == taskNum)
                {
                    break;
                }
                if (tasks.Peek() <= threads.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (tasks.Peek() > threads.Peek())
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskNum}");
            Console.WriteLine(string.Join(" ",threads.ToList()));
        }
        public static Stack<int> ListToStack(List<int> input)
        {
            Stack<int> result = new Stack<int>();
            foreach (var item in input)
            {
                result.Push(item);
            }
            return result;
        }
        public static Queue<int> ListToQueue(List<int> input)
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
