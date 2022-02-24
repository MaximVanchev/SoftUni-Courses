using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IUserService userService;

        public PlayerService(IRepository _repo , IUserService _userService)
        {
            repo = _repo;
            userService = _userService;
        }

        public void AddPlayer(PlayerViewModel model)
        {
            if (GetPlayerByFullName(model.FullName) != null)
            {
                throw new ArgumentException("Player exist !");
            }

            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            repo.Add(player);
            repo.SaveChanges();
        }

        public Player GetPlayerByFullName(string name)
        {
            return repo.All<Player>().FirstOrDefault(x => x.FullName == name);
        }

        public IEnumerable<PlayerViewModel> GetAllPlayers()
        {
            return repo.All<Player>().Select(x => new PlayerViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                Position = x.Position,
                Speed = x.Speed,
                Endurance = x.Endurance,
                Description = x.Description
            });
        }

        public IEnumerable<PlayerViewModel> GetAllPlayersWithUserId(string userId)
        {
            return repo.All<Player>().Where(p => p.UserPlayers.Any(u => u.UserId == userId))
                .Select(x => new PlayerViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                    Position = x.Position,
                    Speed = x.Speed,
                    Endurance = x.Endurance,
                    Description = x.Description
                });
        }

        public bool IsValidPlayer(PlayerViewModel model)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.FullName) || 
                string.IsNullOrWhiteSpace(model.ImageUrl) ||
                string.IsNullOrWhiteSpace(model.Position) ||
                string.IsNullOrWhiteSpace(model.Description) ||
                model.Speed == null ||
                model.Endurance == null)
            {
                isValid = false;
            }
            else if (model.FullName.Length < 5 || model.FullName.Length > 80)
            {
                isValid = false;
            }
            else if (model.Position.Length < 5 || model.Position.Length > 20)
            {
                isValid = false;
            }
            else if (model.Speed < 0 || model.Speed > 10)
            {
                isValid = false;
            }
            else if (model.Endurance < 0 || model.Endurance > 10)
            {
                isValid = false;
            }
            else if (model.Description.Length > 200)
            {
                isValid = false;
            }

            return isValid;
        }

        public Player GetPlayerById(int id)
        {
            return repo.All<Player>().FirstOrDefault(x => x.Id == id);
        }

        public void AddPlayerToUser(int playerId, string userId)
        {
            User user = userService.GetUserById(userId);
            Player player = GetPlayerById(playerId);

            UserPlayer userPlayer = new UserPlayer()
            {
                UserId = userId,
                PlayerId = playerId
            };

            repo.Add(userPlayer);
            repo.SaveChanges();
        }

        public void RemovePlayerFromUser(int playerId, string userId)
        {

            var userplayer =  repo.All<UserPlayer>().First(x => x.UserId == userId && x.PlayerId == playerId);

            repo.Delete(userplayer);
            repo.SaveChanges();
        }
    }
}
