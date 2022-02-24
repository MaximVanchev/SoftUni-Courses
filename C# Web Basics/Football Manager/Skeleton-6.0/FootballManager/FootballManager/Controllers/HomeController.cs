namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Models;

    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index()
        {
            LeyoutViewModel leyout = new LeyoutViewModel(User.IsAuthenticated);

            if (leyout.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return this.View(leyout);
        }
    }
}
