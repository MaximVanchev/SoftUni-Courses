using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
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
            LeyoutViewModel model = new LeyoutViewModel(User.IsAuthenticated);

            return View(model);
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

            (bool isCurrect, string userId) = userService.IsLoginCurrect(model);

            if (isCurrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();

                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                return Redirect("/");
            }

            return View(new ErrorViewModel("Login incorect !") , "/Error");
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool isValid , ErrorViewModel error) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(error, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                return View(new ErrorViewModel(aex.Message) , "/Error");
            }
            catch (Exception)
            {
                return View(new ErrorViewModel("Unexpected Error !") , "/Error");
            }

            return Redirect("/Users/Login");
        }
    }
}
