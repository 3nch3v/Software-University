using SharedTrip.ViewModels.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedTrip.Services.Contracts
{
    public interface IUserService
    {
        Task AddUserAsync(UserRegistrationInputModel input);

        string GetUserId(UserLoginInputModel input);

        ICollection<string> UserValidation(UserRegistrationInputModel input);
    }
}
