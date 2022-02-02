using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsPassed = new Queue<string>();
            Queue<string> waitingCars = new Queue<string>();
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            string command = null;
            while (command != "END")
            {
                int currentDigit = greenLightSeconds;
                command = Console.ReadLine();
                if (command == "green")
                {
                    while (waitingCars.Count != 0)
                    {
                        if (waitingCars.Peek().Length > currentDigit + freeWindowSeconds)
                        {
                            char hitLetter = Reverse(waitingCars.Peek())[waitingCars.Peek().Length - (currentDigit + freeWindowSeconds)-1];
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{waitingCars.Peek()} was hit at {hitLetter}.");
                            return;
                        }
                        else if (waitingCars.Peek().Length == currentDigit + freeWindowSeconds)
                        {
                            carsPassed.Enqueue(waitingCars.Dequeue());
                            waitingCars = new Queue<string>();
                        }
                        else
                        {
                            carsPassed.Enqueue(waitingCars.Peek());
                            if (Math.Sign((currentDigit - waitingCars.Peek().Length)) == 1 || currentDigit - waitingCars.Peek().Length == 0)
                            {
                                currentDigit -= waitingCars.Dequeue().Length; 
                            }
                            else
                            {
                                waitingCars = new Queue<string>();
                            }
                        }
                    }
                }
                else
                {
                    waitingCars.Enqueue(command);
                }
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carsPassed.Count} total cars passed the crossroads.");
        }
        public static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
