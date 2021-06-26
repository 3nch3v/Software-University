namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Receipts;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public HttpResponse Index()
        {
            var receipts = new AllReceiptsViewModel
            {
                Receipts = this.receiptsService.GetAll(),
            };

            return this.View(receipts);
        }
    }
}
