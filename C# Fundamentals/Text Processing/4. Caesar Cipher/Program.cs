using System;

namespace _4._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string encryptedText = null;
                for (int j = 0; j < input.Length; j++)
                {
                    encryptedText += Convert.ToChar(Convert.ToInt32(input[j]) + 3)   ;
                }
            Console.WriteLine(encryptedText);
        }
    }
}
