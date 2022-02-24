using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        void AddPlayer(PlayerViewModel model);

        Player GetPlayerById(int id);

        void AddPlayerToUser(int playerId, string userId);

        void RemovePlayerFromUser(int playerId , string userId);

        Player GetPlayerByFullName(string name);

        bool IsValidPlayer(PlayerViewModel model);

        IEnumerable<PlayerViewModel> GetAllPlayers();

        IEnumerable<PlayerViewModel> GetAllPlayersWithUserId(string userId);
    }
}
