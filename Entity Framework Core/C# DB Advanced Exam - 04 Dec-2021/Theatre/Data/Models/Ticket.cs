using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(GlobalConstants.TICKET_PRICE_MIN_VALUE , GlobalConstants.TICKET_PRICE_MAX_VALUE)]
        public decimal Price { get; set; }

        [Required]
        [Range(GlobalConstants.TICKET_ROWNUMBER_MIN_VALUE , GlobalConstants.TICKET_ROWNUMBER_MAX_VALUE)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        [ForeignKey(nameof(PlayId))]
        public virtual Play Play { get; set; }

        [Required]
        public int TheatreId { get; set; }

        [ForeignKey(nameof(TheatreId))]
        public virtual Theatre Theatre { get; set; }
    }
}
