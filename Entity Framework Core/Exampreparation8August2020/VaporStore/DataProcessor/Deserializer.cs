namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using Newtonsoft.Json;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Dto.Import;
    using Castle.Core.Internal;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesImportModels = JsonConvert.DeserializeObject<ICollection<GameImportModel>>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Game> games = new List<Game>();
            List<Developer> devs = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (var currGame in gamesImportModels)
            {
                if (!IsValid(currGame)
                    || currGame.Tags.Length == 0
                    || currGame.Tags.All(t => t.IsNullOrEmpty()))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var dev = devs.FirstOrDefault(d => d.Name == currGame.Developer);
                if (dev == null)
                {
                    dev = new Developer
                    {
                        Name = currGame.Developer
                    };

                    devs.Add(dev);
                }

                var genre = genres.FirstOrDefault(g => g.Name == currGame.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = currGame.Genre
                    };

                    genres.Add(genre);
                }

                List<Tag> currTags = new List<Tag>();

                foreach (var currTag in currGame.Tags)
                {
                    var tag = tags.FirstOrDefault(g => g.Name == currTag);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = currTag
                        };

                        tags.Add(tag);
                    }

                    currTags.Add(tag);
                }

                Game game = new Game()
                {
                    Name = currGame.Name,
                    Price = currGame.Price,
                    ReleaseDate = DateTime.ParseExact(currGame.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = dev,
                    Genre = genre,
                    GameTags = currTags.Select(tag => new GameTag
                    {
                        Tag = tag
                    }).ToList()
                };

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersModels = JsonConvert.DeserializeObject<ICollection<UserImputModel>>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<User> users = new List<User>();

            foreach (var currUser in usersModels)
            {
                if (!IsValid(currUser)
                || currUser.Cards.Count == 0
                || !currUser.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var newUser = new User
                {
                    Username = currUser.Username,
                    FullName = currUser.FullName,
                    Email = currUser.Email,
                    Age = currUser.Age,
                    Cards = currUser.Cards.Select(c => new Card
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = c.Type
                    }).ToList()
                };

                users.Add(newUser);
                sb.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count} cards"!);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var purchasesDto = XmlConverter.Deserializer<PurchasesInputModel>(xmlString, "Purchases");

            StringBuilder sb = new StringBuilder();
            List<Purchase> purchases = new List<Purchase>();

            foreach (var currPurchase in purchasesDto)
            {
                var card = context.Cards.FirstOrDefault(c => c.Number == currPurchase.Card);
                var came = context.Games.FirstOrDefault(c => c.Name == currPurchase.Title);

                var newPurchase = new Purchase
                {
                    Type = Enum.Parse<PurchaseType>(currPurchase.Type),
                    ProductKey = currPurchase.Key,
                    Date = DateTime.ParseExact(currPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Card = card,
                    Game = came
                };

                if (!IsValid(newPurchase))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                purchases.Add(newPurchase);
                sb.AppendLine($"Imported {newPurchase.Game.Name} for {card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
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