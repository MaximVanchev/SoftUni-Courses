using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        [Required]
        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}
