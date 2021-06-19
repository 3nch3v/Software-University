namespace CarShop.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarShop.ViewModels;

    public interface ICarsService
    {
        ICollection<CarViewModel> GetAllCars(string userId);

        Task AddCar(CarInputModel input);

        List<string> CarValidation(CarInputModel input);

    }
}
