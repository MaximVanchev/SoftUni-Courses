using BusStation.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface ITicketService
    {
        bool IsValidDestination(TicketsCreateViewModel model);

        void AddDestination(TicketsCreateViewModel model , string userId);
        IEnumerable<> GetAllUserTickets(string id);
    }
}
