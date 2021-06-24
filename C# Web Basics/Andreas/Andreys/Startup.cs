using Andreys.Data;
using Andreys.Services;
using Andreys.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System.Threading.Tasks;

namespace Andreys
{
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
                    .Add<IProductsService, ProductsService>()
                    .Add<AndreysDbContext>())
                .WithConfiguration<AndreysDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
