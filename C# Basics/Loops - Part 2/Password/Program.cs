using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = Console.ReadLine();
            string passIn = Console.ReadLine();
            while (pass != passIn)
            {
                passIn = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {user}!");
        }
    }
}
