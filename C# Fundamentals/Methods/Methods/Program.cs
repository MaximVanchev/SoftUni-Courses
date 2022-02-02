using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numTree = int.Parse(Console.ReadLine());
            Console.WriteLine(smallestOfThreeNumbers(numOne, numTwo, numTree));
        }
        static int smallestOfThreeNumbers(int n1, int n2,int n3)
        {
            int result = int.MaxValue;
            if (n1 < result)
            {
                result = n1;
            }
            if (n2 < result)
            {
                result = n2;
            }
            if (n3 < result)
            {
                result = n3;
            }
            return result;
        }
    }
}
