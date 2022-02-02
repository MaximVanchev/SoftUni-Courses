namespace MusicHub
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;
    using MusicHub.Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();
            DbInitializer.ResetDatabase(context);

            Console.WriteLine("Metod 1");

            Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine("Metod 2");

            Console.WriteLine(ExportSongsAboveDuration(context , 4));
        }

        //2. All Albums Produced by Given Producer
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            //IQueryable<Album> albums = (IQueryable<Album>)context.Producers.FirstOrDefault(p => p.Id == producerId).Albums.OrderByDescending(a => a.Price);
            //var albums = context.Albums.ToArray()
            //    .Where(a => a.ProducerId == producerId)
            //    .Select(a => new
            //    {
            //        a.Name,
            //        Price = a.Price.ToString("F2"),
            //        ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
            //        ProducerName = a.Producer.Name,
            //        Songs = a.Songs.Select(s => new
            //        {
            //            s.Name,
            //            Price = s.Price.ToString("F2"),
            //            WaiterName = s.Writer.Name
            //        }).OrderByDescending(s => s.Name).ThenBy(s => s.WaiterName).ToArray()
            //    }).OrderByDescending(a => a.Price).ToArray();
            var albums = context.Producers
               .FirstOrDefault(p => p.Id == producerId)
               .Albums
               .Select(album => new
               {
                   Name = album.Name,
                   ReleaseDate = album.ReleaseDate,
                   ProducerName = album.Producer.Name,
                   Songs = album.Songs.Select(song => new
                   {
                       Name = song.Name,
                       Price = song.Price,
                       WriterName = song.Writer.Name,
                   })
                   .OrderByDescending(x => x.Name)
                   .ThenBy(x => x.WriterName)
                   .ToList(),
                   TotalAlbumPrice = album.Price
               })
               .OrderByDescending(a => a.TotalAlbumPrice)
               .ToList();
            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        //3. Songs Above Given Duration
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.ToArray().Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name ,
                    Writer = s.Writer.Name ,
                    SongPerformer = s.SongPerformers.ToArray().Select(sp => 
                    $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault() ,
                    AlbumProducer = s.Album.Producer.Name ,
                    Duration = s.Duration.ToString("c",CultureInfo.InvariantCulture)
                }).OrderBy(s => s.SongName).ThenBy(s => s.Writer).ThenBy(s => s.SongPerformer).ToArray();

            StringBuilder result = new StringBuilder();
            int songNumber = 1;
            foreach (var song in songs)
            {
                result.AppendLine($"-Song #{songNumber}");
                result.AppendLine($"---Writer: {song.Writer}");
                result.AppendLine($"---Performer: {song.SongPerformer}");
                result.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                result.AppendLine($"---Duration: {song.Duration}");
                songNumber++;
            }
            return result.ToString().TrimEnd();
        }
    }
}
