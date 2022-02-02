using System;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GameImportDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.GAME_PRICE_MIN_VALUE , 10000000000000000000)]
        public decimal Price { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        public virtual string[] Tags { get; set; }
    }
}
