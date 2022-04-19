namespace BusStation.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using BusStation.Models;

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
                return Redirect("/Destinations/All");
            }

            return this.View(leyout);
        }
    }
}
