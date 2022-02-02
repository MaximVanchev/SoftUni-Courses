namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Common;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";
		private const string SuccessfullyImportedGame
			= "Added {0} ({1}) with {2} tags";
		private const string SuccessfullyImportedUser
			= "Imported {0} with {1} cards";
		private const string SuccessfullyImportedPurchase
			= "Imported {0} for {1}";


		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			List<GameImportDto> gameImportDtos = JsonConvert.DeserializeObject<List<GameImportDto>>(jsonString);

			List<Game> games = new List<Game>();

			List<Developer> devs = new List<Developer>();

			List<Genre> genres = new List<Genre>();

			List<Tag> tags = new List<Tag>();

			foreach (var gameImportDto in gameImportDtos)
            {
                if (!IsValid(gameImportDto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

                if (gameImportDto.Tags.Length == 0)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				bool isGameDateValid = DateTime.TryParseExact(gameImportDto.ReleaseDate, "yyyy-MM-dd"
					, CultureInfo.InvariantCulture , DateTimeStyles.None, out DateTime gameDate);

                if (!isGameDateValid)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Developer dev = devs.FirstOrDefault(d => d.Name == gameImportDto.Developer);
				if (dev == null)
				{
					dev = new Developer() { Name = gameImportDto.Developer };
					devs.Add(dev);
				}

				Genre genre = genres.FirstOrDefault(g => g.Name == gameImportDto.Genre);
				if (genre == null)
				{
					genre = new Genre() { Name = gameImportDto.Genre };
					genres.Add(genre);
				}

				Game game = new Game()
				{
					Name = gameImportDto.Name,
					Price = gameImportDto.Price,
					ReleaseDate = DateTime.ParseExact(gameImportDto.ReleaseDate , "yyyy-MM-dd" , CultureInfo.InvariantCulture),
					Developer = dev,
					Genre = genre,
					GameTags = new List<GameTag>()
				};

                foreach (var tag in gameImportDto.Tags)
                {
					Tag tagDto = tags.FirstOrDefault(g => g.Name == tag);
					if (tagDto == null)
					{
						tagDto = new Tag() { Name = tag };
						tags.Add(tagDto);
					}

					GameTag gameTag = new GameTag() 
					{ 
						Tag = tagDto
					};

					game.GameTags.Add(gameTag);
                }
				games.Add(game);

				sb.AppendLine(String.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
			}

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			List<UserImputDto> userImportDtos = JsonConvert.DeserializeObject<List<UserImputDto>>(jsonString);

			List<User> users = new List<User>();

			List<Card> cards = new List<Card>();

			foreach (var userImportDto in userImportDtos)
			{
				if (!IsValid(userImportDtos))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

                if (String.IsNullOrEmpty(userImportDto.FullName) 
					|| String.IsNullOrEmpty(userImportDto.Username) || String.IsNullOrEmpty(userImportDto.Email))
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				if (userImportDto.Cards.Count == 0)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

                if (userImportDto.Age < GlobalConstants.USER_AGE_MIN_VALUE || userImportDto.Age > GlobalConstants.USER_AGE_MAX_VALUE)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				User user = new User()
				{
					FullName = userImportDto.FullName,
					Username = userImportDto.Username,
					Email = userImportDto.Email,
					Age = userImportDto.Age,
					Cards = new List<Card>()
				};

				bool haveInvalidCard = false;

				foreach (var cardDto in userImportDto.Cards)
				{
                    if (!IsValid(cardDto))
                    {
						sb.AppendLine(ErrorMessage);
						haveInvalidCard = true;
						break;
					}

					bool isCardTypeValid = Enum.TryParse(typeof(CardType), cardDto.Type, out object cardType);

                    if (!isCardTypeValid)
                    {
						sb.AppendLine(ErrorMessage);
						haveInvalidCard = true;
						break;
					}

					Card card = new Card()
					{
						Number = cardDto.Number,
						Cvc = cardDto.Cvc,
						Type = (CardType)cardType
					};

					Card cardCheck = cards.FirstOrDefault(c => c.Number == cardDto.Number);
					if (cardCheck == null)
					{
						cards.Add(card);
						user.Cards.Add(card);
					}
				}

				if (haveInvalidCard) continue;

				users.Add(user);

				sb.AppendLine(String.Format(SuccessfullyImportedUser , user.Username , user.Cards.Count));
			}

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			var serializer = new XmlSerializer(typeof(PurchaseXmlImportDto[]), new XmlRootAttribute("Purchases"));

			PurchaseXmlImportDto[] purchaseXmlImportDtos = serializer.Deserialize(new StringReader(xmlString)) as PurchaseXmlImportDto[];

			HashSet<Purchase> purchases = new HashSet<Purchase>();

			foreach (var purchaseXmlImportDto in purchaseXmlImportDtos)
			{
				if (!IsValid(purchaseXmlImportDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				bool isPurchaseDateValid = DateTime.TryParseExact(purchaseXmlImportDto.Date
					, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture
					, DateTimeStyles.None, out DateTime purchaseDate);

				bool isPurchaseTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseXmlImportDto.Type, out object purchaseType);

				var game = context.Games.FirstOrDefault(g => g.Name == purchaseXmlImportDto.Title);

				var card = context.Cards.FirstOrDefault(c => c.Number == purchaseXmlImportDto.Card);

				if (!isPurchaseTypeValid)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				if (game == null)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				if (card == null)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				if (!isPurchaseDateValid)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Purchase purchase = new Purchase()
				{
					Game = game,

					Type = (PurchaseType)purchaseType,

					ProductKey = purchaseXmlImportDto.ProductKey,

					Card = card,

					Date = purchaseDate
				};

				purchases.Add(purchase);

				sb.AppendLine(String.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
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