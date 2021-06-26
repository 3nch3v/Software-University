namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var userId = this.User.Id;
            var username = this.userService.GetUsernameById(userId);

            return this.View(username);
        }
    }
}
