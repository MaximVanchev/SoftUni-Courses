using System;
using System.Collections.Generic;

namespace _1._Generic_Box_of_String
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Box<string> newBox = new Box<string>(Console.ReadLine());
                boxes.Add(newBox);
            }
            foreach (var item in boxes)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
