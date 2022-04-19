﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.ViewModels.Destinations
{
    public class DestinationViewModel
    {
        public int Id { get; set; }

        public string DestinationName { get; set; }

        public string Origin { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string ImageUrl { get; set; }

        public int TicketsCount { get; set; }
    }
}
