using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Services.Contracts;
using SharedTrip.ViewModels.UserModels;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginInputModel input)
        {
            var userId = this.userService.GetUserId(input);
            if (userId == null)
            {
                return this.View();
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegistrationInputModel input)
        {
            if (this.userService.UserValidation(input).Any())
            {
                return this.View();
            }

            this.userService.AddUserAsync(input);

            return this.Redirect(nameof(Login));
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
