namespace CarShop.Controllers
{
    using System.Linq;

    using CarShop.Services.Contracts;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(
            ICarsService carsService,
            IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var cars = new AllCarsViewModel 
            {
                Cars = this.carsService.GetAllCars(this.User.Id),
            };
            return this.View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.usersService.IsUserMechanic(this.User.Id))
            {
                return this.Redirect("/Cars/All");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CarInputModel input)
        {
            if (this.carsService.CarValidation(input).Any())
            {
                var errors = this.carsService.CarValidation(input);
                return this.Error(errors);
            }

            if (!this.usersService.IsUserMechanic(this.User.Id))
            {
                input.OwnerId = this.User.Id;
                this.carsService.AddCar(input);
            }

            return this.Redirect("/Cars/All");
        }
    }
}
