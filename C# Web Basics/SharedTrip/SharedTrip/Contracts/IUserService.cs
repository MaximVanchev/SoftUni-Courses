using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        (bool IsValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);

        void RegisterUser(RegisterViewModel model);

        (bool IsCurrect, string userId) IsLoginCurrect(LoginViewModel model);
    }
}
