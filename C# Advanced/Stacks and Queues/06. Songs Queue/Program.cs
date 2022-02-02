using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsInQueue = new Queue<string>();
            List<string> input = Console.ReadLine().Split(", ").ToList();
            songsInQueue = ListInQueue(input, songsInQueue);
            while (songsInQueue.Count != 0)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Play")
                {
                    songsInQueue.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    if (!songsInQueue.Contains(AddSongName(command)))
                    {
                        songsInQueue.Enqueue(AddSongName(command));
                    }
                    else
                    {
                        Console.WriteLine($"{AddSongName(command)} is already contained!");
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songsInQueue));
                }
            }
            Console.WriteLine($"No more songs!");
        }
        public static Queue<string> ListInQueue(List<string> a,Queue<string> b)
        {
            foreach (var item in a)
            {
                b.Enqueue(item);
            }
            return b;
        }
        public static string AddSongName(string[] a)
        {
            StringBuilder sb = new StringBuilder(null);
            for (int i = 1; i < a.Length; i++)
            {
                if (i < a.Length - 1)
                {
                    sb.Append(a[i] + " "); 
                }
                else
                {
                    sb.Append(a[i]);
                }
            }
            return sb.ToString();
        }
    }
}
