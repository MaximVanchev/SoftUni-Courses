using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Article.title = input[0];
            Article.content = input[1];
            Article.author = input[2];
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Article command = new Article(input);
            }
            Article.ariclePrint();
        }
    }
    public class Article
    {
        public static string title;
        public static string content;
        public static string author;
        public Article(List<string> command)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        {
            if (command[0] == "Edit:")
            {
                command.RemoveAt(0);
                Article.content = string.Join(" ",command);
            }
            else if (command[0] == "ChangeAuthor:")
            {
                command.RemoveAt(0);
                Article.author = string.Join(" ",command);
            }
            else if (command[0] == "Rename:")
            {
                command.RemoveAt(0);
                Article.title = string.Join(" ",command);
            }

        }
        public static void ariclePrint()
        {
            Console.WriteLine($"{title} - {content}: {author}");
        }
    }
}
