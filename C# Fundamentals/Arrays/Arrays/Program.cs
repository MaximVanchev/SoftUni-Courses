using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] wagons = new int[int.Parse(Console.ReadLine())];
            int sum = 0;
            string furstLine = null;
            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
                furstLine += wagons[i] + " ";
            }
            Console.WriteLine(furstLine);
            Console.WriteLine(sum);
        }
    }
}
