using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.Models;
using BusStation.ViewModels.Destinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Controllers
{
    [Authorize]
    public class DestinationsController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationsController(Request request, IDestinationService _destinationService)
            : base(request)
        {
            destinationService = _destinationService;
        }

        public Response All()
        {
            DestinationListViewModel destinationListViewModel = new DestinationListViewModel(User.IsAuthenticated)
            {
                Destinations = destinationService.GetAllDestinations()
            };

            return View(destinationListViewModel, "/Destinations/All");
        }

        public Response Add()
        {
            LeyoutViewModel model = new LeyoutViewModel(User.IsAuthenticated);

            return View(model);
        }

        [HttpPost]
        public Response Add(DestinationAddViewModel model)
        {
            if (!destinationService.IsValidDestination(model))
            {
                return Redirect("/Destinations/Add");
            }

            try
            {
                destinationService.AddDestination(model);
            }
            catch (Exception)
            {
                return Redirect("/Destinations/Add");
            }

            return Redirect("/Destinations/All");
        }
    }
}
