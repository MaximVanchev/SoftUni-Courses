using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.ViewModels.Tickets
{
    public class TicketsListViewModel
    {
        public TicketsListViewModel(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public IEnumerable<TicketsViewModel> Tickets { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
