namespace Andreys.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using Andreys.Services.Contracts;
    using Andreys.ViewModels.UserModels;

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
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);
            return this.Redirect("/Home/Home");
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
                return this.Redirect("/Users/Register");
            }

            this.userService.AddUserAsync(input);

            return this.Redirect(nameof(Login));
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/Home/Index");
        }
    }
}
