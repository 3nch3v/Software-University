namespace CarShop.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarShop.ViewModels;

    public interface IUsersService
    {
        Task AddUser(UserRegistrationInputModel input);

        string GetUserId(UserLoginInputModel input);

        ICollection<string> UserValidation(UserRegistrationInputModel input);

        public bool IsUserMechanic(string userId);
    }
}
