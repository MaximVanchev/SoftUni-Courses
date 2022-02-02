using System;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringNum = Console.ReadLine();
            int num = int.Parse(stringNum);
            while (stringNum != "END")
            {
                Console.WriteLine(trueOrFalsePrint(num));
                stringNum = Console.ReadLine();
            }
        }
        static int revers(string n)
        {
            string result = null;
            for (int i = n.Length - 1; i >= 0; i--)
            {
                result += n[i];
            }
            return Convert.ToInt32(result);
        }
        static string trueOrFalsePrint(int n)
        {
            if (n == revers(Convert.ToString(n)))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
