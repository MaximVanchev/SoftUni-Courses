using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Destinations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository repo;

        public DestinationService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddDestination(DestinationAddViewModel model)
        {
            string date = model.Date.ToString("d");
            string time = model.Date.ToString("t");

            var destination = new Destination()
            {
                ImageUrl = model.ImageUrl,
                DestinationName = model.DestinationName,
                Origin = model.Origin,
                Date = time,
                Time = date
            };

            repo.Add(destination);
            repo.SaveChanges();
        }

        public IEnumerable<DestinationViewModel> GetAllDestinations()
        {
            return repo.All<Destination>().Include(d => d.Tickets).Select(d => new DestinationViewModel()
            {
                Id = d.Id,
                Date = d.Date,
                DestinationName = d.DestinationName,
                ImageUrl = d.ImageUrl,
                Origin = d.Origin,
                TicketsCount = d.Tickets.Count(),
                Time = d.Time
            });
        }

        public bool IsValidDestination(DestinationAddViewModel model)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.ImageUrl) ||
                string.IsNullOrWhiteSpace(model.Origin) ||
                string.IsNullOrWhiteSpace(model.DestinationName))
            {
                isValid = false;
            }
            else if (model.DestinationName.Length < 2 || model.DestinationName.Length > 50)
            {
                isValid = false;
            }
            else if (model.Origin.Length < 2 || model.Origin.Length > 50)
            {
                isValid = false;
            }
            else if (model.Date.ToString("d") == null)
            {
                isValid = false;
            }
            else if (model.Date.ToString("t") == null)
            {
                isValid = false;
            }
            else if (model.Date < DateTime.Now)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
