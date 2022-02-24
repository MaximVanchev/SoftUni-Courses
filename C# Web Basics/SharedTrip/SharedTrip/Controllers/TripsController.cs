using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(
            Request request ,
            ITripService _tripService) 
            : base(request)
        {
            tripService = _tripService;
        }

        [Authorize]
        public Response Add() => View();

        [HttpPost]
        public Response Add(AddViewModel model)
        {
            (bool IsValid , IEnumerable<ErrorViewModel> errors) = tripService.ValidateTrip(model);

            if (!IsValid)
            {
                return View( errors , "/Error");
            }

            try
            {
                tripService.AddTrip(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel> { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<AllViewModel> allTrips = tripService.GetAllTrips();

            return View(allTrips);
        }

        [Authorize]
        public Response Details(string tripId)
        {
            DetailsViewModel detailsViewModel = tripService.GetTripById(tripId);

            return View(detailsViewModel);
        }

        public Response AddUserToTrip(string tripId)
        {
            var userId = User.Id;

            if (!tripService.IsUserAdded(userId, tripId))
            {
                return Details(tripId);
            }

            try
            {
                tripService.AddUserToTrip(userId, tripId);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel> { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel> { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return View("/Trips/All");
        }
    }
}
