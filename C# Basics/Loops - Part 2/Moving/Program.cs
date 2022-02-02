using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int m = a * c * b;
            string end = Console.ReadLine();
            int sum = 0;
            while (end != "Done")
            {
                int num = int.Parse(end);
                sum += num;
                if (sum > m)
                {
                    Console.WriteLine($"No more free space! You need {sum - m} Cubic meters more.   ");
                    return;
                }
                end = Console.ReadLine();
            }
            Console.WriteLine($"{m - sum} Cubic meters left.");
        }
    }
}
