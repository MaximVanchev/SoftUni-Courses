using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            long facturialOne = long.Parse(Console.ReadLine());
            long facturialTwo = long.Parse(Console.ReadLine());
            Console.WriteLine($"{divisionPrint(facturialOne,facturialTwo):F2}");

        }
        static long facturielCalculationOne(long f1)
        {
            long facturialCount = 1;

            for (int i = 1; i <= f1; i++)
            {
                facturialCount *= i;
            }
            return facturialCount;
        }
        static long facturielCalculationTwo(long f2)
        {
            long facturialCount = 1;

            for (int i = 1; i <= f2; i++)
            {
                facturialCount *= i;
            }
            return facturialCount;
        }
        static decimal divisionPrint(long f1 ,long f2)
        {
            decimal result = facturielCalculationOne(f1) / facturielCalculationTwo(f2);
            return result;
        }

    }
}
