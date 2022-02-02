    using System;

    namespace Even_Powers_of_2
    {
        class Program
        {
            static void Main(string[] args)
            {
                int safeNum = 1;
                int num = int.Parse(Console.ReadLine());
                for (int i = 0; i <= num; i+=2)
                {
                        Console.WriteLine(safeNum);
                        safeNum = safeNum * 2 * 2;
                }
            }
        }
    }
    