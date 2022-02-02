using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
        }
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LogoUrl { get; set; }

        [MaxLength(10)]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public int PrimaryKitColorId { get; set; }

        [ForeignKey(nameof(PrimaryKitColorId))]
        public virtual Color PrimaryKitColor { get; set; }

        [Required]
        public int SecondaryKitColorId { get; set; }

        [ForeignKey(nameof(SecondaryKitColorId))]
        public virtual Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        public virtual Town Town { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeGames { get; set; }

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayGames { get; set; }
    }
}
