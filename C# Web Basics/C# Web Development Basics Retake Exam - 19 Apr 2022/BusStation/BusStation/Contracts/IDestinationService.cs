using BusStation.ViewModels.Destinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IDestinationService
    {
        IEnumerable<DestinationViewModel> GetAllDestinations();

        bool IsValidDestination(DestinationAddViewModel model);

        void AddDestination(DestinationAddViewModel model);
    }
}
