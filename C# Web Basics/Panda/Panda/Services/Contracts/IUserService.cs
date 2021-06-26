namespace Panda.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Panda.ViewModels.UserModels;

    public interface IUserService
    {
        Task AddUserAsync(UserRegistrationInputModel input);

        string GetUserId(UserLoginInputModel input);

        UsernameViewModel GetUsernameById(string userId);

        ICollection<string> UserValidation(UserRegistrationInputModel input);
    }
}
