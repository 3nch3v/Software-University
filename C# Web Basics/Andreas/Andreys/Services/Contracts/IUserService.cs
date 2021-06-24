namespace Andreys.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Andreys.ViewModels.UserModels;

    public interface IUserService
    {
        Task AddUserAsync(UserRegistrationInputModel input);

        string GetUserId(UserLoginInputModel input);

        ICollection<string> UserValidation(UserRegistrationInputModel input);
    }
}
