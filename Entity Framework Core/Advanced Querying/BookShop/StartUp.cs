namespace BookShop
{
    using BookShop.Models;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db , input));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            //Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(input)));
            //Console.WriteLine(GetBooksByCategory(db , input));
            //Console.WriteLine(GetBooksReleasedBefore(db , input));
            //Console.WriteLine(GetAuthorNamesEndingIn(db , input));
            //Console.WriteLine(GetBookTitlesContaining(db , input));
            //Console.WriteLine(GetBooksByAuthor(db , input));
            //Console.WriteLine(CountBooks(db , int.Parse(input)));
            Console.WriteLine(CountCopiesByAuthor(db)); 
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();
            Book[] books = context.Books.ToArray().Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower()).OrderBy(b => b.Title).ToArray();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();
            Book[] books = context.Books.ToArray().Where(b => b.Copies < 5000 &&
            b.EditionType.ToString() == "Gold").OrderBy(b => b.BookId).ToArray();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();
            Book[] books = context.Books.ToArray().Where(b => b.Price > 40).OrderByDescending(b => b.Price).ToArray();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:F2}");
            }
            return result.ToString().TrimEnd();
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder result = new StringBuilder();
            Book[] books = context.Books.ToArray().Where(b => b.ReleaseDate.Value.Year != year).OrderBy(b => b.BookId).ToArray();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();
            string[] categories = input.ToLower().Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Book> books = new List<Book>();
            foreach (var item in categories)
            {
                books.AddRange(context.Books.Include(b => b.BookCategories).ThenInclude(b => b.Category)
                    .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == item)));
            }
            books = books.Distinct().OrderBy(b => b.Title).ToList();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new StringBuilder();

            Book[] books = context.Books.ToArray().Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date , "dd-MM-yyyy" , null))
                .OrderByDescending(b => b.ReleaseDate).ToArray();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }
            return result.ToString().TrimEnd();
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var authors = context.Authors.ToArray().Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { Name = $"{a.FirstName} {a.LastName}"}).OrderBy(a => a.Name).ToArray();

            foreach (var author in authors)
            {
                result.AppendLine(author.Name);
            }
            return result.ToString().TrimEnd();
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //StringBuilder result = new StringBuilder();

            //var books = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower()))
            //    .Select(b => b.Title).OrderBy(b => b).ToList();

            //foreach (var book in books)
            //{
            //    result.AppendLine(book);
            //}
            //return result.ToString().TrimEnd();
            var result = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var output = string.Join(Environment.NewLine, result);
            return output;
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            StringBuilder result = new StringBuilder();

            var books = context.Books.ToArray().Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new 
                { 
                    BookTitle = b.Title , 
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                }).ToArray();

            foreach (var book in books)
            {
                result.AppendLine($"{book.BookTitle} ({book.AuthorName})");
            }
            return result.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCountWithLength = context.Books.Where(b => b.Title.Length > lengthCheck).Count();
            return booksCountWithLength;
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var authors = context.Authors.Select(a => new
            {
                Name = $"{a.FirstName} {a.LastName}",
                Copies = a.Books.Select(b => b.Copies).Sum()
            }).OrderByDescending(a => a.Copies).ToArray();


            foreach (var author in authors)
            {
                result.AppendLine($"{author.Name} - {author.Copies}");
            }
            return result.ToString().TrimEnd();
            //var result = context.Authors
            //  .Select(x => new
            //  {
            //      x.FirstName,
            //      x.LastName,
            //      TotalCopies = x.Books.Sum(b => b.Copies)
            //  })
            //  .OrderByDescending(x => x.TotalCopies)
            //  .ToList();

            //StringBuilder sb = new StringBuilder();

            //foreach (var info in result)
            //{

            //    sb.AppendLine($"{info.FirstName} {info.LastName} - {info.TotalCopies}");
            //}

            //return sb.ToString().Trim();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categories = context.Categories.Select(c => new
            {
                CategoryName = c.Name,
                TotalProfit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
            }).OrderByDescending(c => c.TotalProfit).ThenBy(c => c.CategoryName);


            foreach (var category in categories)
            {
                result.AppendLine($"{category.CategoryName} ${category.TotalProfit:F2}");
            }
            return result.ToString().TrimEnd();
            //var result = context.Categories
            //  .Select(x => new
            //  {
            //      x.Name,
            //      Profit = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
            //  })
            //  .OrderByDescending(x => x.Profit)
            //  .ThenBy(x => x.Name);

            //StringBuilder sb = new StringBuilder();

            //foreach (var info in result)
            //{
            //    sb.AppendLine($"{info.Name} ${info.Profit}");
            //}

            //return sb.ToString().Trim();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categories = context.Categories.Select(c => new
            {
                CategoryName = c.Name,
                Books = c.CategoryBooks.Select(cb => new
                {
                    BookTitle = cb.Book.Title,
                    BookReleaseDate = cb.Book.ReleaseDate.Value
                }).OrderByDescending(b => b.BookReleaseDate).Take(3)
            }).OrderBy(c => c.CategoryName);


            foreach (var category in categories)
            {
                result.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Year})"); 
                }
            }
            return result.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            Book[] books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToArray();
            foreach (var book in books)
            {
                book.Price += 5;
            }
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            return context.Books.Where(b => b.Copies < 4200).Delete();
        }
    }
}
