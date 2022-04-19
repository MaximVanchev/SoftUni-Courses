using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.ViewModels.Destinations
{
    public class DestinationAddViewModel
    {
        public string DestinationName { get; set; }

        public string Origin { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}
