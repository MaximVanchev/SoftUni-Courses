using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Data.Models;
using FootballManager.Models;
using FootballManager.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request , IPlayerService _playerService) 
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response All()
        {
            PlayersListViewModel playersListViewModel = new PlayersListViewModel(User.IsAuthenticated)
            {
                Players = playerService.GetAllPlayers()
            };

            return View(playersListViewModel , "/Players/All");
        }

        [Authorize]
        public Response Collection()
        {

            PlayersListViewModel playersListViewModel = new PlayersListViewModel(User.IsAuthenticated)
            {
                Players = playerService.GetAllPlayersWithUserId(User.Id)
            };

            return View(playersListViewModel , "/Player/Collection");
        }

        [Authorize]
        public Response Add()
        {
            LeyoutViewModel model = new LeyoutViewModel(User.IsAuthenticated);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public Response Add(PlayerViewModel model)
        {
            if (!playerService.IsValidPlayer(model))
            {
                return Redirect("/Players/Add");
            }

            try
            {
                playerService.AddPlayer(model);
            }
            catch (Exception)
            {
                return Redirect("/Players/Add");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            Player player = playerService.GetPlayerById(playerId);

            if (player == null)
            {
                return Redirect("/Players/All");
            }

            playerService.AddPlayerToUser(playerId, User.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            Player player = playerService.GetPlayerById(playerId);

            if (player == null)
            {
                return Redirect("/Players/All");
            }

            playerService.RemovePlayerFromUser(playerId, User.Id);

            return Redirect("/");
        }
    }
}
