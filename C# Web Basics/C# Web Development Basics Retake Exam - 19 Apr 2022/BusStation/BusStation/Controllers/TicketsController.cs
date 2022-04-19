using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.Models;
using BusStation.Models.Tickets;
using BusStation.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(Request request, ITicketService _ticketService)
            : base(request)
        {
            ticketService = _ticketService;
        }

        public Response Create(int Id)
        {
            LeyoutTichetsViewModel model = new LeyoutTichetsViewModel(User.IsAuthenticated);

            model.DestinationId = Id;

            return View(model);
        }

        [HttpPost]
        public Response Create(TicketsCreateViewModel model)
        {
            if (!ticketService.IsValidDestination(model))
            {
                return Redirect("/Tickets/Create");
            }

            try
            {
                ticketService.AddDestination(model , User.Id);
            }
            catch (Exception)
            {
                return Redirect("/Tickets/Create");
            }

            return Redirect("/Destinations/All");
        }

        public Response MyTickets()
        {
            var moidel = ticketService.GetAllUserTickets(User.Id);

            return View();
        }
    }
}
