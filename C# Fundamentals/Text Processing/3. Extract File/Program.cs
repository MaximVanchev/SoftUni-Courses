using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> file = Console.ReadLine().Split(new char[] { '\\', '.' }).ToList();
            Console.WriteLine($"File name: {file[file.Count - 2]}");
            Console.WriteLine($"File extension: {file[file.Count - 1]}");
        }
    }
}
