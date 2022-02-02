using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; }

        [Required]
        public byte ScoredGoals { get; set; }

        [Required]
        public byte Assists { get; set; }

        [Required]
        public byte MinutesPlayed { get; set; }
    }
}
