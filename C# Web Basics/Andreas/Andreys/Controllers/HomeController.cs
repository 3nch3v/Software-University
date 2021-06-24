namespace Andreys.App.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using Andreys.Services.Contracts;
    using Andreys.ViewModels.ProductModels;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home/Home");
            }

            return this.View();
        }

        [Authorize]
        public HttpResponse Home()
        {
            var userId = this.User.Id;

            var products = new AllProductsViewModel
            {
                Products = this.productsService.GetAll(),
            };

            return this.View(products);
        }
    }
}
