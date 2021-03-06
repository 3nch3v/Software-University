using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //DbInitializer.ResetDatabase(db);

            var input = Console.ReadLine();

            var result = GetBooksReleasedBefore(db, input);

            Console.WriteLine(result);
        }


        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentCulture))
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            //var books = context.Books
            //    .Include(x => x.BookCategories)
            //    .ThenInclude(x => x.Category)
            //    .ToList()
            //    .Where(book => book.BookCategories
            //        .Any(category => categories.Contains(category.Category.Name.ToLower())))
            //    .Select(book => book.Title)
            //    .OrderBy(title => title)
            //    .ToList();

            var books = context.BooksCategories
                .Select(x => new
                {
                    BookTitle = x.Book.Title,
                    CategoryName = x.Category.Name
                })
                .Where(x => categories.Contains(x.CategoryName.ToLower()))
                .OrderBy(x => x.BookTitle)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.HasValue && book.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var editionType = Enum.Parse<EditionType>("Gold");

            var books = context.Books
                             .Where(x => x.EditionType == editionType && x.Copies < 5000)
                             .Select(x => new
                             {
                                 x.BookId,
                                 x.Title
                             })
                             .OrderBy(x => x.BookId)
                             .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var titles = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();
                
            StringBuilder sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
