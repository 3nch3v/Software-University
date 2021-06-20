namespace Git
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using Git.Data;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Git.Services.Contracts;
    using Git.Services;

    public class Startup
    {
        public static async Task Main()
         => await HttpServer
                 .WithRoutes(routes => routes
                     .MapStaticFiles()
                     .MapControllers())
                 .WithServices(services => services
                     .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUserService, UserService>()
                    .Add<IRepositoriesService, RepositoriesService>()
                    .Add<ICommitsService, CommitsService>()
                     .Add<ApplicationDbContext>())
                 .WithConfiguration<ApplicationDbContext>(context => context
                     .Database.Migrate())
                 .Start();
    }
}
