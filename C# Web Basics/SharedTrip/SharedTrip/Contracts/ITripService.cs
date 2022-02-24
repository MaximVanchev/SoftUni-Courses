using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool IsValid , IEnumerable<ErrorViewModel> erorr) ValidateTrip(AddViewModel model);

        bool IsUserAdded(string userId, string tripId);

        void AddTrip(AddViewModel model);

        IEnumerable<AllViewModel> GetAllTrips();

        DetailsViewModel GetTripById(string id);

        void AddUserToTrip(string userId , string tripId);
    }
}
