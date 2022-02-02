namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(PlayXmlImportDto[]), new XmlRootAttribute("Plays"));

            PlayXmlImportDto[] playXmlImportDtos = serializer.Deserialize(new StringReader(xmlString)) as PlayXmlImportDto[];

            HashSet<Play> plays = new HashSet<Play>();

            foreach (var playXmlImportDto in playXmlImportDtos)
            {
                if (!IsValid(playXmlImportDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(playXmlImportDto.Duration, "c"
                    , CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan playDuration);

                bool isGenreValid = Enum.TryParse(typeof(Genre), playXmlImportDto.Genre, out object playGenre);

                if (!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (playDuration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playXmlImportDto.Title,
                    Duration = playDuration,
                    Rating = playXmlImportDto.Rating,
                    Genre = (Genre)playGenre,
                    Description = playXmlImportDto.Description,
                    Screenwriter = playXmlImportDto.Screenwriter
                };

                plays.Add(play);

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {

            StringBuilder sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CastXmlImportDto[]), new XmlRootAttribute("Casts"));

            CastXmlImportDto[] castXmlImportDtos = serializer.Deserialize(new StringReader(xmlString)) as CastXmlImportDto[];

            HashSet<Cast> casts = new HashSet<Cast>();

            foreach (var castXmlImportDto in castXmlImportDtos)
            {
                if (!IsValid(castXmlImportDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castXmlImportDto.FullName,
                    IsMainCharacter = castXmlImportDto.IsMainCharacter,
                    PhoneNumber = castXmlImportDto.PhoneNumber,
                    PlayId = castXmlImportDto.PlayId
                };

                casts.Add(cast);

                string role = "lesser";

                if (cast.IsMainCharacter)
                {
                    role = "main";
                }

                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, role));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<TheatreJsonImportDto> theatreJsonImportDtos = JsonConvert
                .DeserializeObject<ICollection<TheatreJsonImportDto>>(jsonString).ToList();

            HashSet<Theatre> theatres = new HashSet<Theatre>();
            int ticketCount = 0;
            foreach (var theatreJsonImportDto in theatreJsonImportDtos)
            {
                if (!IsValid(theatreJsonImportDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (String.IsNullOrEmpty(theatreJsonImportDto.Name) || String.IsNullOrEmpty(theatreJsonImportDto.Director))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (theatreJsonImportDto.Tickets.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreJsonImportDto.Name,
                    NumberOfHalls = theatreJsonImportDto.NumberOfHalls,
                    Director = theatreJsonImportDto.Director,
                    Tickets = new List<Ticket>()
                };

                foreach (var ticketJsonImportDto in theatreJsonImportDto.Tickets)
                {
                    if (!IsValid(ticketJsonImportDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //if (!context.Plays.Any(p => p.Id == ticketJsonImportDto.PlayId))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketJsonImportDto.Price,
                        RowNumber = ticketJsonImportDto.RowNumber,
                        PlayId = ticketJsonImportDto.PlayId,
                        Theatre = theatre
                    };

                    theatre.Tickets.Add(ticket);
                    ticketCount++;
                }

                theatres.Add(theatre);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
