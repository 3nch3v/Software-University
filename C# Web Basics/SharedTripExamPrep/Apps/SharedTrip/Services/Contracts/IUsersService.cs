using System.Threading.Tasks;

namespace SharedTrip.Services.Contracts
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        Task Create(string username, string email, string password);

        bool IsUsernameAvaileble(string username);

        bool IsEmailAvailable(string email);

    }
}
