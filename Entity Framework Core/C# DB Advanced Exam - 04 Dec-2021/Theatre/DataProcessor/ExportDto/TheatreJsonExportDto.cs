using System;
using System.Collections.Generic;
using System.Text;

namespace Theatre.DataProcessor.ExportDto
{
    public class TheatreJsonExportDto
    {
        public string Name { get; set; }

        public sbyte Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public ICollection<TicketJsonExportDto> Tickets { get; set; }
    }
}
