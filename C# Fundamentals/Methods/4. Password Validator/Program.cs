using System;

namespace _4._Password_Validator
{
    class Program
    {
        private static bool wrongBool = false;

        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            passwordCharactersValidator(pass);
            passwordLettersAndDigitsValidator(pass);
            passwordTwoBigDigitsValidator(pass);
            passwordValidator();
        }
        static void passwordCharactersValidator(string input)
        {
            if (input.Length < 6 || input.Length > 10)
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
                wrongBool = true;
            }
        }
        static void passwordLettersAndDigitsValidator(string input)
        {
            bool currentDigit = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < 47 || input[i] > 57 && input[i] < 65 || input[i] > 90 && input[i] < 97 || input[i] > 122)
                {
                    currentDigit = true;
                    wrongBool = true;
                }
            }
            if (currentDigit == true)
            {
                Console.WriteLine($"Password must consist only of letters and digits");
            }
        }
        static void passwordTwoBigDigitsValidator(string input)
        {
            int bigLetters = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 65 && input[i] < 90 )
                {
                    bigLetters++;
                }
            }
            if (bigLetters < 2)
            {
                Console.WriteLine($"Password must have at least 2 digits");
                wrongBool = true;
            }
        }
        static void passwordValidator()
        {
            if (wrongBool == false)
            {
                Console.WriteLine($"Password is valid");
            }
        }

    }
}
