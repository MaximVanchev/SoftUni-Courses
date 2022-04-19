using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.ViewModels.Destinations
{
    public class DestinationListViewModel
    {
        public DestinationListViewModel(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public IEnumerable<DestinationViewModel> Destinations { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
