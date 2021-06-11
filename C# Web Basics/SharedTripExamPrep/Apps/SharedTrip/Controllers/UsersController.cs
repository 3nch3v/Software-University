using SharedTrip.Services.Contracts;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = usersService.GetUserId(input.Username, input.Password);

            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(input.Username) 
                || input.Username.Length < 5
                || input.Username.Length > 20)
            {
                return Error("Username should be between 5 and 20 characters");
            }

            if (string.IsNullOrEmpty(input.Email)
                || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return Error("Invalid Email!");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return Error("Password don't match!");
            }

            if (string.IsNullOrEmpty(input.Password)
                || input.Password.Length < 6
                || input.Password.Length > 20)
            {
                return Error("Password should be between 5 and 20 characters!");
            }

            usersService.Create(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
