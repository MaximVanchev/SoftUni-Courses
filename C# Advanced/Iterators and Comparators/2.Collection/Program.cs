using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            list.RemoveAt(0);
            ListyIterator<string> listyIterator = new _ListyIterator.ListyIterator<string>(list);
            string command = null;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    listyIterator.Print();
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
