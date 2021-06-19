namespace BattleCards.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BattleCards.ViewModels;

    public interface IUserService
    {
        Task AddUser(UserRegistrationInputModel input);

        string GetUserId(UserLoginInputModel input);

        ICollection<string> UserValidation(UserRegistrationInputModel input);
    }
}
