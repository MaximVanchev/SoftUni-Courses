using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository repo;

        public TicketService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddDestination(TicketsCreateViewModel model , string userId)
        {
            model.DestinationId = 1;

            for (int i = 0; i < model.TicketsCount; i++)
            {
                var ticket = new Ticket()
                {
                    Price = Convert.ToDecimal(model.Price),
                    UserId = userId,
                    DestinationId = model.DestinationId
                };

                repo.Add(ticket);
            }

            repo.SaveChanges();
        }

        public bool IsValidDestination(TicketsCreateViewModel model)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.Price) ||
                model.TicketsCount == null)
            {
                isValid = false;
            }
            else if (Convert.ToDecimal(model.Price) < 10 || Convert.ToDecimal(model.Price) > 90)
            {
                isValid = false;
            }
            else if (model.TicketsCount > 10)
            {
                isValid = false;
            }
            else if (model.TicketsCount < 1)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
