namespace BattleCards.Controllers
{
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using BattleCards.Services.Contracts;
    using BattleCards.ViewModels;

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
            return this.Redirect("/Cards/All");
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
                return this.Error(this.userService.UserValidation(input));
            }

            this.userService.AddUser(input);

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
