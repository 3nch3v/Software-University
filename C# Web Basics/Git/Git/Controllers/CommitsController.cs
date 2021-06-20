namespace Git.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using Git.Services.Contracts;
    using Git.ViewModels;

    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly ICommitsService commitsService;

        public CommitsController(
            IRepositoriesService repositoriesService,
            ICommitsService commitsService)
        {
            this.repositoriesService = repositoriesService;
            this.commitsService = commitsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var userId = this.User.Id;
            var commits = new AllCommitsViewModel
            {
                Commits = this.commitsService.GetAll(userId),
            };

            return this.View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repositpry = this.repositoriesService.GetRepository(id);
            return this.View(repositpry);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CommitInputmodel intput)
        {
            var errors = this.commitsService.CommitInputModelValidation(intput);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            intput.CreatorId = this.User.Id;
            this.commitsService.CreateCommitAsync(intput);

            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var userId = this.User.Id;
            var creatorId = this.commitsService.GetCreatorId(id);
            if (userId != creatorId)
            {
                return this.Redirect("/All");
            }

            this.commitsService.DeleteAsync(id);

            return this.Redirect("/Commits/All");
        }
    }
}
