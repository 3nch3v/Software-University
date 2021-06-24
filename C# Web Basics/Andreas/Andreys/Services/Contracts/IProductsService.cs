namespace Andreys.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Andreys.ViewModels.ProductModels;

    public interface IProductsService
    {
        Task AddProductAsync(ProductInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<string> InputValidation(ProductInputModel input);

        IEnumerable<ProductViewModel> GetAll();

        SigleProductViewModel GetById(int id);

        bool IsExisting(int id);
    }
}
