using System;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numTree = int.Parse(Console.ReadLine());
            Console.WriteLine(sum(numOne,numTwo,numTree));
        }
        static int sum(int n1,int n2,int n3)
        {
            int currentSum = n1 + n2;
            return currentSum - n3;
        }
    }
}