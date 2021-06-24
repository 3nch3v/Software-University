namespace Andreys.Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using Andreys.Data;
    using Andreys.Data.Models;
    using Andreys.Services.Contracts;
    using Andreys.ViewModels.UserModels;
    using static Andreys.Common.GlobalConstants;

    public class UserService : IUserService
    {
        private readonly AndreysDbContext dbContext;

        public UserService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUserAsync(UserRegistrationInputModel input)
        {
            var user = new User
            {
                Username = input.Username,
                Password = ComputeHash(input.Password),
                Email = input.Email,
            };

            await this.dbContext.Users.AddAsync(user);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<string> UserValidation(UserRegistrationInputModel input)
        {
            ICollection<string> errorList = new HashSet<string>();

            if (this.dbContext.Users.Any(u => u.Username == input.Username))
            {
                errorList.Add(string.Format(UsernameAlreadyExist, input.Username));
            }

            if (this.dbContext.Users.Any(u => u.Email == input.Email))
            {
                errorList.Add(string.Format(EmailAlreadyExist, input.Email));
            }

            if (string.IsNullOrWhiteSpace(input.Username) || input.Username.Length > UsernameMaxLength || input.Username.Length < UsernameMinLength)
            {
                errorList.Add(string.Format(InvalidUsernameLength, UsernameMinLength, UsernameMaxLength));
            }

            if (string.IsNullOrWhiteSpace(input.Email) || !new RegularExpressionAttribute(EmailValidationPattern).IsValid(input.Email))
            {
                errorList.Add(InvalidEmail);
            }

            if (string.IsNullOrWhiteSpace(input.Password) || input.Password.Length < PasswordMinLength || input.Password.Length > PasswordMaxLength)
            {
                errorList.Add(string.Format(InvalidPasswordLength, PasswordMinLength, PasswordMaxLength));
            }

            if (input.Password != input.ConfirmPassword)
            {
                errorList.Add(PasswordDoesNotMath);
            }

            return errorList;
        }

        public string GetUserId(UserLoginInputModel input)
        {
            var user = this.dbContext.Users
                .Where(u => u.Username == input.Username && u.Password == ComputeHash(input.Password))
                .FirstOrDefault();
            return user?.Id;
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
