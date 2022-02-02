using System;

namespace Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int twoNums = 0;
            int treeNums = 0;
            int fourNums = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    twoNums++;
                }
                if (num % 3 == 0)
                {
                    treeNums++;
                }
                if (num % 4 == 0)
                {
                    fourNums++;
                }
            }
            Console.WriteLine($"{((double)twoNums/n)*100:F2}%");
            Console.WriteLine($"{((double)treeNums /n)*100:F2}%");
            Console.WriteLine($"{((double)fourNums /n)*100:F2}%");
        }
    }
}
