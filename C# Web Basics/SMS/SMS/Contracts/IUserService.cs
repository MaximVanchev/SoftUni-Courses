using SMS.Data.Models;
using SMS.Models;
using SMS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool IsValid, ErrorViewModel error) ValidateModel(RegisterViewModel model);

        void RegisterUser(RegisterViewModel model);

        User GetUserById(string id);

        (bool IsCurrect, string userId) IsLoginCurrect(LoginViewModel model);
    }
}
