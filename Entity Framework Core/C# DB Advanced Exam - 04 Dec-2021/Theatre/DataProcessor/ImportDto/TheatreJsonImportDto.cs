using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheatreJsonImportDto
    {
        [Required]
        [MaxLength(GlobalConstants.THEATRE_NAME_MAX_LENGTH)]
        [MinLength(GlobalConstants.THEATRE_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.THEATRE_NUMBEROFHALLS_MIN_VALUE, GlobalConstants.THEATRE_NAME_MAX_LENGTH)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(GlobalConstants.THEATRE_DIRECTOR_MAX_LENGTH)]
        [MinLength(GlobalConstants.THEATRE_DIRECTOR_MIN_LENGTH)]
        public string Director { get; set; }

        public virtual ICollection<TicketJsonImportDto> Tickets { get; set; }
    }
}
