using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int biggest = int.MinValue;
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            while (n >= num)
            {
                int finNum = int.Parse(Console.ReadLine());
                if (finNum > biggest) biggest = finNum;
                num++;
            }
            Console.WriteLine(biggest);
        }
    }
}
