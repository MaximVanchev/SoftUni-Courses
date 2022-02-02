using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> listWithNames = new HashSet<string>();
            for (int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                listWithNames.Add(name);
            }
            foreach (var item in listWithNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
