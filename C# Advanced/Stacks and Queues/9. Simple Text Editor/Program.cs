using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> text = new Stack<string>();
            Stack<string> previousCommands = new Stack<string>();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                List<string> command = Console.ReadLine().Split().ToList();
                if (command[0] == "1")
                {
                    text.Push(command[1]);
                    previousCommands.Push(1.ToString());
                }
                else if (command[0] == "2")
                {
                    int lettersToDelete = int.Parse(command[1]);
                    while (lettersToDelete != 0)
                    {
                        if (text.Peek().Length > lettersToDelete)
                        {
                            previousCommands.Push(DeleteLastLetters(lettersToDelete, text.Peek())[1]);
                            text.Push(DeleteLastLetters(lettersToDelete, text.Pop())[0]);
                            lettersToDelete = 0;
                        }
                        else if (text.Peek().Length == lettersToDelete)
                        {
                            previousCommands.Push(text.Peek());
                            text.Pop();
                            lettersToDelete = 0;
                        }
                        else
                        {
                            previousCommands.Push(text.Peek());
                            lettersToDelete -= text.Peek().Length;
                            text.Pop();
                            
                        }
                    }
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(StackToString(text)[Convert.ToInt32(command[1])-1]);
                }
                else
                {
                    if (previousCommands.Peek() == "1")
                    {
                        text.Pop();
                        previousCommands.Pop();
                    }
                    else
                    {
                        text.Push(previousCommands.Pop());
                    }
                }
            }
        }
        public static string StackToString(Stack<string> a)
        {
            StringBuilder sb = new StringBuilder();
            Stack<string> reverseStack = new Stack<string>();
            foreach (var item in a)
            {
                reverseStack.Push(item);
            }
            foreach (var item in reverseStack)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
        public static string[] DeleteLastLetters(int a,string b)
        {
            StringBuilder sb = new StringBuilder(b);
            StringBuilder sbTwo = new StringBuilder(b);
            sbTwo.Remove(0, b.Length - a);
            sb.Remove(b.Length - a, a);
            string[] result = new string[2] { sb.ToString(), sbTwo.ToString() };
            return result;
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
