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

            //var input = int.Parse(Console.ReadLine());

            //var result = GetMostRecentBooks(db);

            //Console.WriteLine(result);

            Console.WriteLine(RemoveBooks(db));
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
           var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            return context.SaveChanges();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
           var books =  context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        x.Book.Title,
                        x.Book.ReleaseDate
                    })
                        .OrderByDescending(x => x.ReleaseDate)
                        .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"--{categorie.Name}");

                foreach (var book in categorie.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Money = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.Money)
                .ThenBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"{categorie.Name} ${categorie.Money:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    TotalBooksCopies = x.Books.Select(x => x.Copies).Sum(),
                })
                .OrderByDescending(x => x.TotalBooksCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalBooksCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookList = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Select(x => x.Title)
                .ToList();

            return bookList.Count();
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => EF.Functions.Like(x.LastName, $"{input}%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Books = x.Books.OrderBy(x => x.BookId).ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                foreach (var books in author.Books)
                {
                    sb.AppendLine($"{books.Title} ({author.FirstName} {author.LastName})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input)) //EF.Functions.Like(x.FirstName, $"%{input}"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
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
