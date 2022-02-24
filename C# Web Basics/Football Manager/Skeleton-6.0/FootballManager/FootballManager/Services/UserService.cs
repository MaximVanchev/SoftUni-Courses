using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public bool IsValidUser(RegisterViewModel model)
        {
            bool isValid = true;

            string regexPattern = @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex regex = new Regex(regexPattern);

            if (string.IsNullOrWhiteSpace(model.Username) || 
                string.IsNullOrWhiteSpace(model.Email) || 
                string.IsNullOrWhiteSpace(model.Password))
            {
                isValid = false;
            }
            else if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                isValid = false;
            }
            else if (model.Email.Length < 10 || model.Email.Length > 60 || !regex.IsMatch(model.Email))
            {
                isValid = false;
            }
            else if (model.Password.Length < 5 || model.Password.Length > 20 || model.Password != model.ConfirmPassword)
            {
                isValid = false;
            }

            return isValid;
        }

        private string HashPassword(string password)
        {
            byte[] passwordByteArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordByteArray));
            }
        }

        public void RegisterUser(RegisterViewModel model)
        {
            if (GetUserByUsername(model.Username) != null)
            {
                throw new ArgumentException("Username exist !");
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email
            };

            user.Password = HashPassword(model.Password);

            repo.Add(user);
            repo.SaveChanges();
        }

        private User GetUserByUsername(string username)
        {
            return repo.All<User>().FirstOrDefault(x => x.Username == username);
        }

        public User GetUserById(string id)
        {
            return repo.All<User>().FirstOrDefault(x => x.Id == id);
        }

        public (bool isCurrect, string userId) IsLoggedCurrect(LoginViewModel model)
        {
            bool isCurrect = true;

            string userId = string.Empty;

            User user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCurrect = HashPassword(model.Password) == user.Password;
            }

            if (isCurrect)
            {
                userId = user.Id;
            }

            return (isCurrect, userId);
        }
    }
}
