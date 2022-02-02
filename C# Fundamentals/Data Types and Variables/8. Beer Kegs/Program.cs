using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegNum = int.Parse(Console.ReadLine());
            double biggest = int.MinValue;
            string biggestKeg = "";
            for (int i = 0; i < kegNum; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());
                double kegSum = kegHeight * 3.14 * (kegRadius * kegRadius);
                if (kegSum > biggest)
                {
                    biggest = kegSum;
                    biggestKeg = kegModel;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
