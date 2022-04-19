using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.ViewModels.Tickets
{
    public class TicketsCreateViewModel
    {
        public string Price { get; set; }

        public int TicketsCount { get; set; }

        public int DestinationId { get; set; }
    }
}
