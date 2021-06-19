namespace CarShop.Controllers
{
    using System.Linq;

    using CarShop.Services.Contracts;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input);
            if (userId == null)
            {
                return this.View();
            }

            this.SignIn(userId);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegistrationInputModel input)
        {
            if (this.usersService.UserValidation(input).Any())
            {
                return this.Error(this.usersService.UserValidation(input));
            }

            this.usersService.AddUser(input);

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
