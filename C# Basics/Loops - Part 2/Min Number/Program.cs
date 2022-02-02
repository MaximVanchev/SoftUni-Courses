using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallest = int.MaxValue;
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            while (n >= num)
            {
                int finNum = int.Parse(Console.ReadLine());
                if (finNum < smallest) smallest = finNum;
                num++;
            }
            Console.WriteLine(smallest);
        }
    }
}
