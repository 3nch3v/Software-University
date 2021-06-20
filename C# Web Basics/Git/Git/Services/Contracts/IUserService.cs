namespace Git.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Git.ViewModels;

    public interface IUserService
    {
        Task AddUserAsync(UserRegistrationInputModel input);

        string GetUserId(UserLoginInputModel input);

        ICollection<string> UserValidation(UserRegistrationInputModel input);
    }
}
