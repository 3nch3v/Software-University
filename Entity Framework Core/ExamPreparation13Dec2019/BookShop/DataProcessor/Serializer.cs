using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + ' ' + a.LastName,
                    Books = a.AuthorsBooks
                        .ToList()
                        .OrderByDescending(b => b.Book.Price)
                        .Select(b => new
                        {
                            BookName = b.Book.Name,
                            BookPrice = b.Book.Price.ToString("f2")
                        })
                     
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToList();

            var json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookExportModel[]), new XmlRootAttribute("Books"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                var books = context.Books
                    .ToArray()
                    .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                    .OrderByDescending(b => b.Pages)
                    .ThenByDescending(b => b.PublishedOn)
                    .Select(b => new BookExportModel
                    {
                        Pages = b.Pages,
                        Name = b.Name,
                        Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                    })
                    .Take(10)
                    .ToArray();

                xmlSerializer.Serialize(stringWriter, books, namespaces);
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}