using BusStation.Data.Models;
using BusStation.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IUserService
    {
        void RegisterUser(RegisterViewModel model);

        bool IsValidUser(RegisterViewModel model);

        (bool isCurrect , string userId) IsLoggedCurrect(LoginViewModel model);

        User GetUserById(string id);
    }
}
