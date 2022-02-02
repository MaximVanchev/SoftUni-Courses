namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        private const string MainCharacterString = "Plays main character in '{0}'.";
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.Include(t => t.Tickets).Where(t => t.NumberOfHalls >= numbersOfHalls 
            && t.Tickets.Count >= 20).ToList();

            List<TheatreJsonExportDto> theatreJsonExportDtos = new List<TheatreJsonExportDto>();

            foreach (var theatre in theatres)
            {
                theatre.Tickets = theatre.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).ToList();

                TheatreJsonExportDto theatreJsonExportDto = new TheatreJsonExportDto()
                {
                    Name = theatre.Name,
                    Halls = theatre.NumberOfHalls,
                    TotalIncome = theatre.Tickets.Select(t => t.Price).Sum(),
                    Tickets = new List<TicketJsonExportDto>()
                };

                foreach (var ticket in theatre.Tickets)
                {
                    TicketJsonExportDto ticketJsonExportDto = new TicketJsonExportDto()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber
                    };

                    theatreJsonExportDto.Tickets.Add(ticketJsonExportDto);
                }

                theatreJsonExportDto.Tickets = theatreJsonExportDto.Tickets.OrderByDescending(t => t.Price).ToList();

                theatreJsonExportDtos.Add(theatreJsonExportDto);
            }

            theatreJsonExportDtos = theatreJsonExportDtos.OrderByDescending(t => t.Halls).ThenBy(t => t.Name).ToList();

            string resultJson = JsonConvert.SerializeObject(theatreJsonExportDtos, Formatting.Indented);

            return resultJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            Play[] plays = context.Plays.Include(p => p.Casts).Where(p => p.Rating <= rating).ToArray();

            List<PlayXmlExportDto> playXmlExportDtos = new List<PlayXmlExportDto>();

           

            foreach (var play in plays)
            {
                string playRatingDto =play.Rating.ToString();

                if (play.Rating == 0)
                {
                    playRatingDto = "Premier";
                }

                PlayXmlExportDto playXmlExportDto = new PlayXmlExportDto()
                {
                    Title = play.Title,
                    Duration = play.Duration.ToString(),
                    Rating = playRatingDto,
                    Genre = play.Genre.ToString(),
                    Actors = null
                };

                List<ActorXmlExportDto> actorXmlExportDtos = new List<ActorXmlExportDto>();

                foreach (var cast in play.Casts.Where(c => c.IsMainCharacter == true).ToList())
                {
                    ActorXmlExportDto actorXmlExportDto = new ActorXmlExportDto()
                    {
                        FullName = cast.FullName,
                        MainCharacter = String.Format(MainCharacterString, play.Title)
                    };

                    actorXmlExportDtos.Add(actorXmlExportDto);
                }

                playXmlExportDto.Actors = actorXmlExportDtos.OrderByDescending(a => a.FullName).ToArray();

                playXmlExportDtos.Add(playXmlExportDto);
            }

            playXmlExportDtos = playXmlExportDtos.OrderBy(x => x.Title).ThenByDescending(x => x.Genre).ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);
            var serializer = new XmlSerializer(typeof(PlayXmlExportDto[]), new XmlRootAttribute("Plays"));
            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, playXmlExportDtos.ToArray(), namespaces);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
