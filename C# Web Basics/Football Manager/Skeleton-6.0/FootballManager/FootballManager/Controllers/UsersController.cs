using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Models;
using FootballManager.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request , IUserService _userService) 
            : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            LeyoutViewModel leyout = new LeyoutViewModel(User.IsAuthenticated);

            return View(leyout);
        }

        public Response Register()
        {
            LeyoutViewModel model = new LeyoutViewModel(User.IsAuthenticated);

            return View(model);
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();
            return Redirect("/");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            SignOut();

            (bool isCurrect, string userId) = userService.IsLoggedCurrect(model);

            if (isCurrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();

                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                return Redirect("/Players/All");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            bool isValid = userService.IsValidUser(model);

            if (!isValid)
            {
                return Redirect("/Users/Register");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (Exception)
            {
                return Redirect("/Users/Register");
            }

            return Redirect("/Users/Login");
        }
    }
}
