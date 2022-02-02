using System;

namespace Data_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numTree = int.Parse(Console.ReadLine());
            int numFour = int.Parse(Console.ReadLine());
            double sum = (((double)(numOne + numTwo) / numTree) * numFour);
            Console.WriteLine(sum);
        }
    }
}
