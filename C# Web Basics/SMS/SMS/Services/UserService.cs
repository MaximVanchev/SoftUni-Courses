using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using SMS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMS.Services
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
            bool isCurrect = true;

            string userId = string.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCurrect = user.Password == HashPassword(model.Password);
            }

            if (isCurrect)
            {
                userId = user.Id;
            }

            return (isCurrect, userId);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            if (GetUserByUsername(model.Username) != null)
            {
                throw new ArgumentException("User already exist !");
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Cart = cart,
                CartId = cart.Id
            };

            user.Password = HashPassword(model.Password);

            repo.Add(user);
            repo.SaveChanges();
        }

        private User GetUserByUsername(string username)
        {
            return repo.All<User>().FirstOrDefault(x => x.Username == username);
        }

        private string HashPassword(string password)
        {
            byte[] passwordByteArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordByteArray));
            }
        }

        public (bool IsValid, ErrorViewModel error) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;

            ErrorViewModel error = null;

            StringBuilder sb = new StringBuilder();

            string regexPattern = @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex regex = new Regex(regexPattern);

            if (string.IsNullOrWhiteSpace(model.Username) || 
                string.IsNullOrWhiteSpace(model.Email) || 
                string.IsNullOrWhiteSpace(model.Password))
            {
                isValid = false;
                sb.AppendLine(" Username , Email , Password are required !");
            }

            if (!regex.IsMatch(model.Email))
            {
                isValid = false;
                sb.AppendLine(" Email is not valid !");
            }

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                isValid = false;
                sb.AppendLine(" Username must be 5 to 20 characters !");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                sb.AppendLine(" Password must be 6 to 20 characters !");
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                sb.AppendLine(" Password must be the same as ConfirmPassword !");
            }

            error = new ErrorViewModel(sb.ToString());

            return (isValid, error);
        }

        public User GetUserById(string id)
        {
            return repo.All<User>().FirstOrDefault(u => u.Id == id);
        }

        private object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
