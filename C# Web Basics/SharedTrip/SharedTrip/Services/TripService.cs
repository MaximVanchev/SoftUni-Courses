using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;

        public TripService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddTrip(AddViewModel model)
        {
            DateTime date;

            DateTime.TryParseExact(model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Seats = model.Seats,
                ImagePath = model.ImagePath,
                DepartureTime = date,
                Description = model.Description
            };

            repo.Add(trip);
            repo.SaveChanges();
        }

        public void AddUserToTrip(string userId , string tripId)
        {
            var user = repo.All<User>().FirstOrDefault(u => u.Id == userId);

            var trip = repo.All<Trip>().FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or Trip not found");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                UserId = userId,
                User = user
            });

            repo.SaveChanges();
        }

        public IEnumerable<AllViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(t => new AllViewModel()
                {
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Id = t.Id
                });
        }

        public DetailsViewModel GetTripById(string id)
        {
            return repo.All<Trip>()
                .Where(t => t.Id == id)
                .Select(t => new DetailsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    ImagePath = t.ImagePath,
                    Description = t.Description,
                    Seats = t.Seats
                }).FirstOrDefault();
        }

        public bool IsUserAdded(string userId, string tripId)
        {
            bool isValid = true;

            var userTrip = repo.All<UserTrip>()
                .Where(t => t.UserId == userId && t.TripId == tripId)
                .FirstOrDefault();

            if (userTrip != null)
            {
                isValid = false;
            }

            return isValid;
        }

        public (bool IsValid, IEnumerable<ErrorViewModel> erorr) ValidateTrip(AddViewModel model)
        {
            bool isValid = true;

            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.StartPoint) ||
                string.IsNullOrWhiteSpace(model.EndPoint) ||
                string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("StartPoint , EndPoint , DepartureTime is required"));
            }

            if (model.Seats == null || model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats must be in range 2 to 6 characters and is required"));
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description max length is 80 characters and is required"));
            }

            DateTime date;

            if(!DateTime.TryParseExact(model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None ,
                out date))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("DepartureTime is in wrong format"));
            };

            return (isValid, errors);
        }
    }
}
