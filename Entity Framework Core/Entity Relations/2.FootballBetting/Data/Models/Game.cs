using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int GameId { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        public virtual Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        public virtual Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        public decimal Result { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
