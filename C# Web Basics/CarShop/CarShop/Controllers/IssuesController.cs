namespace CarShop.Controllers
{
    using CarShop.Services.Contracts;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;

        public IssuesController(
            IIssuesService issuesService,
            IUsersService usersService)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
        }

        public HttpResponse CarIssues(string carId)
        {
            var car = this.issuesService.CarIssues(carId);
            return this.View(car);
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            var myCarId = new CarIdViewModel
            {
                CarId = carId,
            };
            return this.View(myCarId);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(IssueInputModel input)
        {
            this.issuesService.AddCarIssue(input);

            return this.Redirect($"/Issues/CarIssues?carId={input.CarId} ");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            this.issuesService.DeleteIssue(issueId, carId);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            if (this.usersService.IsUserMechanic(this.User.Id))
            {
                this.issuesService.Fix(issueId, carId);
            }
 
            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
