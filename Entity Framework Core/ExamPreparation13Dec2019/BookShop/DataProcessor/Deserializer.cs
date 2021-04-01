namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BookImportmodel[]), new XmlRootAttribute("Books"));
            TextReader reader = new StringReader(xmlString);
            var booksModels = (IEnumerable<BookImportmodel>)serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            List<Book> books = new List<Book>();

            foreach (var currBook in booksModels)
            {
                if (!IsValid(currBook))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book()
                {
                    Name = currBook.Name,
                    Genre = Enum.Parse<Genre>(currBook.Genre),
                    Pages = currBook.Pages,
                    Price = currBook.Price,
                    PublishedOn = DateTime.ParseExact(currBook.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                books.Add(book);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorModels = JsonConvert.DeserializeObject<ICollection<AuthorImportModel>>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Author> authors = new List<Author>();

            foreach (var currAuthor in authorModels)
            {
                if (!IsValid(currAuthor) || authors.Any(a => a.Email == currAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = currAuthor.FirstName,
                    LastName = currAuthor.LastName,
                    Phone = currAuthor.Phone,
                    Email = currAuthor.Email,
                };

                foreach (var currBook in currAuthor.Books)
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == currBook.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Book = book
                    });
                }

                if (!author.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{currAuthor.FirstName} {currAuthor.LastName}", author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}