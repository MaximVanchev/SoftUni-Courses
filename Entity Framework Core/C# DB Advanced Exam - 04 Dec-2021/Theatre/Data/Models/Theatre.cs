using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.THEATRE_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.THEATRE_NUMBEROFHALLS_MIN_VALUE , GlobalConstants.THEATRE_NAME_MAX_LENGTH)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(GlobalConstants.THEATRE_DIRECTOR_MAX_LENGTH)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
