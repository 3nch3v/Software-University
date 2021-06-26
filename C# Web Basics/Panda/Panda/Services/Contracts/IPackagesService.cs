namespace Panda.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Panda.ViewModels.Packages;
    using Panda.ViewModels.UserModels;

    public interface IPackagesService
    {
        ICollection<RecepientViewModel> GetRecepients();

        ICollection<PackageViewModel> GetPendingPackages();

        ICollection<PackageViewModel> GetDeliveredPackages();

        Task SetToDelivered(string id);

        Task CreateAsync(PackageInputModel input);

        IEnumerable<string> PackageValidation(PackageInputModel input);
    }
}
