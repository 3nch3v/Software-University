using Git.Services.Contracts;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var repositories = new AllRepositoriesViewModel
            {
                Repositories = this.repositoriesService.GetAll(),
            };
    
            return this.View(repositories);
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(RepositoryInputModel input)
        {
            if (this.repositoriesService.IsInputModelValid(input).Any())
            {
                return this.Error(this.repositoriesService.IsInputModelValid(input));
            }

            input.OwnerId = this.User.Id;
            this.repositoriesService.CreateRepositoryAsync(input);

            return this.Redirect("/Repositories/All");
        }
    }
}
