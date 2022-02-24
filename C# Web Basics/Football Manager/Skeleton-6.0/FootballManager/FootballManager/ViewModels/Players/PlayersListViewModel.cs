using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.ViewModels.Players
{
    public class PlayersListViewModel
    {
        public PlayersListViewModel(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
