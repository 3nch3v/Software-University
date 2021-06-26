using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using Panda.Data;
using Panda.Services;
using Panda.Services.Contracts;
using System.Threading.Tasks;

namespace Panda
{
    class StartUp
    {
        public static async Task Main()
         => await HttpServer
                 .WithRoutes(routes => routes
                     .MapStaticFiles()
                     .MapControllers())
                 .WithServices(services => services
                     .Add<IViewEngine, CompilationViewEngine>()
                     .Add<IUserService, UserService>()
                     .Add<IPackagesService, PackagesService>()
                   .Add<IReceiptsService, ReceiptsService>()
                     .Add<ApplicationDbContext>())
                 .WithConfiguration<ApplicationDbContext>(context => context
                     .Database.Migrate())
                 .Start();
    }
}
