namespace CarShop
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using CarShop.Data;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using CarShop.Services.Contracts;
    using CarShop.Services;

    public class Startup
    {
        public static async Task Main()
             => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUsersService, UsersService>()
                    .Add<ICarsService, CarsService>()
                    .Add<IIssuesService, IssuesService>()
                    .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
