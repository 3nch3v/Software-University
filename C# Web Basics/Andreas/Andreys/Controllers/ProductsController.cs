namespace Andreys.Controllers
{
    using System.Linq;

    using MyWebServer.Http;
    using MyWebServer.Controllers;

    using Andreys.Services.Contracts;
    using Andreys.ViewModels.ProductModels;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(ProductInputModel input)
        {

            if (this.productsService.InputValidation(input).Any())
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.AddProductAsync(input);

            return this.Redirect("/Home/Index");
        }

        [Authorize]
        public HttpResponse Details(int id)
        {
            var product = this.productsService.GetById(id);

            if (product == null)
            {
                return this.BadRequest();
            }

            return this.View(product);
        }

        [Authorize]
        public HttpResponse Delete(int id)
        {
            if (!this.productsService.IsExisting(id))
            {
                return this.BadRequest();
            }

            this.productsService.DeleteAsync(id);

            return this.Redirect("/Home/Home");
        }
    }
}
