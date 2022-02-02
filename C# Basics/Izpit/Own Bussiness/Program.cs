using System;

namespace Own_Bussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int totalSpace = width * length * height;
            string inPut = Console.ReadLine();
            int sum = 0;
            while (inPut != "Done")
            {
                int num = int.Parse(inPut);
                inPut = Console.ReadLine();
                sum += num;
                if (sum > totalSpace)
                {
                    break;
                }
            }
            if (sum > totalSpace)
            {
                Console.WriteLine($"No more free space! You need {sum - totalSpace} Cubic meters more.");
            }
            else if (sum < totalSpace)
            {
                Console.WriteLine($"{totalSpace - sum} Cubic meters left.");
            }
        }
    }
}
