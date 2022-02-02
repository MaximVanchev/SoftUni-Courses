using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = Console.ReadLine();
            string reverseUser = "";
            int count = 0;
            for (int i = user.Length - 1; i >= 0; i--)
            {
                char symbol = user[i];
                reverseUser += symbol;
            }
            while (pass != reverseUser)
            {
                count++;
                if (count == 4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    return;
                }
                Console.WriteLine($"Incorrect password. Try again.");
                pass = Console.ReadLine();
            }
            Console.WriteLine($"User {user} logged in.");

        }
    }
}
