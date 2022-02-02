using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketJsonImportDto
    {

        [Required]
        [Range(GlobalConstants.TICKET_PRICE_MIN_VALUE, GlobalConstants.TICKET_PRICE_MAX_VALUE)]
        public decimal Price { get; set; }

        [Required]
        [Range(GlobalConstants.TICKET_ROWNUMBER_MIN_VALUE, GlobalConstants.TICKET_ROWNUMBER_MAX_VALUE)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
