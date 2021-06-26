namespace Panda.Controllers
{
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.UserModels;

    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IReceiptsService receiptsService;

        public PackagesController(
            IPackagesService packagesService,
            IReceiptsService receiptsService)
        {
            this.packagesService = packagesService;
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public HttpResponse Create()
        {
            var recepients = new AllRecipientsViewModel
            {
                Recipients = this.packagesService.GetRecepients(),
            };

            return this.View(recepients);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(PackageInputModel input)
        {
            if (this.packagesService.PackageValidation(input).Any())
            {
                var recepients = new AllRecipientsViewModel
                {
                    Recipients = this.packagesService.GetRecepients(),
                };

                return this.View(recepients);
            }

            this.packagesService.CreateAsync(input);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public HttpResponse Pending()
        {
            var pendingPackages = new AllPackagesViewModel
            {
                Packages = this.packagesService.GetPendingPackages(),
            };

            return this.View(pendingPackages);
        }

        [Authorize]
        public HttpResponse Delivered()
        {
            var deleveredPackages = new AllPackagesViewModel
            {
                Packages = this.packagesService.GetDeliveredPackages(),
            };

            return this.View(deleveredPackages);
        }

        [Authorize]
        public HttpResponse Deliver(string id)
        {
            this.packagesService.SetToDelivered(id);
            this.receiptsService.CreateReceiptAsync(id);

            return this.Redirect("/Packages/Delivered");
        }
    }
}
