using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public (bool IsCurrect, string userId) IsLoginCurrect(LoginViewModel model)
        {
            bool IsCurrect = false;

            string userId = string.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                IsCurrect = user.Password == HashPassword(model.Password);
            }

            if (IsCurrect)
            {
                userId = user.Id;
            }

            return (IsCurrect, userId);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            if (GetUserByUsername(model.Username) != null)
            {
                throw new ArgumentException("Registration failed");
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
            };

            user.Password = HashPassword(model.Password);

            repo.Add(user);
            repo.SaveChanges();
        }

        private string HashPassword(string password)
        {
            byte[] passwordByteArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordByteArray));
            }
        }

        private User GetUserByUsername(string username)
        {
            return repo
                .All<User>()
                .Where(x => x.Username == username)
                .FirstOrDefault();
        }

        public (bool IsValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;

            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username.Length < 5 || model.Username.Length > 20 || model.Username == null)
            {
                isValid = false;

                errors.Add(new ErrorViewModel("Username must be in range of 5 to 20 characters and is required"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;

                errors.Add(new ErrorViewModel("Email is required"));
            }

            if (model.Password.Length < 6 || model.Password.Length > 20 || model.Password == null)
            {
                isValid = false;

                errors.Add(new ErrorViewModel("Password must be in range of 6 to 20 characters and is required"));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;

                errors.Add(new ErrorViewModel("Password must be the same as confirm possword"));
            }

            return (isValid, errors);
        }
    }
}
