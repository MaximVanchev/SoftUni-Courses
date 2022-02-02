using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PLAY_TITLE_MAX_LENGTH)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(GlobalConstants.PLAY_RATING_MIN_VALUE,GlobalConstants.PLAY_RATING_MAX_VALUE)]
        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PLAY_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PLAY_SCREENWRITER_MAX_LENGTH)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
