using System;

namespace DefiningClasses
{
    public class Program
    {   
        static void Main(string[] args)
        {
            DateModifier newDate = new DateModifier();
            Console.WriteLine(newDate.DateModifierMathod(Console.ReadLine(), Console.ReadLine()));
        }
    }
}
