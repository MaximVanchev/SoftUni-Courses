using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPut = Console.ReadLine();
            int sum = 0;
            while (inPut != "Stop")
            {
                int inPutAsNum = int.Parse(inPut);
                sum += inPutAsNum;
                inPut = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}
    