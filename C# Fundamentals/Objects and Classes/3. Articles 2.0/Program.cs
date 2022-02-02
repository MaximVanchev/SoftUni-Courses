using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Articles2> articles = new List<Articles2>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                List<string> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Articles2 newAeticles = new Articles2();
                newAeticles.title = input[0];
                newAeticles.content = input[1];
                newAeticles.author = input[2];
                articles.Add(newAeticles);
            }
            string criteria = Console.ReadLine();
            if (criteria == "title")
            {
                Console.WriteLine(string.Join(Environment.NewLine,articles.OrderBy(x => x.title)));
            }
            else if (criteria == "content")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(x => x.content)));
            }
            else if (criteria == "author")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(x => x.author)));
            }
        }
    }
    public class Articles2
    {
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public override string ToString()
        {
            return $"{title} - {content}: {author}";
        }
    }
}
