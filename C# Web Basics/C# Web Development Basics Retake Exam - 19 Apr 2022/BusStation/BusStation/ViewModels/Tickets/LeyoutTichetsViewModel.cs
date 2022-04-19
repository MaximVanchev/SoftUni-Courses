
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Models.Tickets
{
    public class LeyoutTichetsViewModel
    {
        public LeyoutTichetsViewModel(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public bool IsAuthenticated { get; set; }

        public int DestinationId { get; set; }
    }
}
