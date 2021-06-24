namespace Andreys.Common
{
    public class GlobalConstants
    {
        public const int UsernameMinLength = 4;

        public const int UsernameMaxLength = 10;

        public const int PasswordMinLength = 6;

        public const int PasswordMaxLength = 20;

        public const int PrductNameMinLength = 4;

        public const int PrductNameMaxLength = 20;

        public const int DescriptionMaxLength = 10;

        public const int UrlMaxLength = 2048;

        public const string InvalidProductName = "Product name schould be between {0} and {1} characters!";

        public const string InvalidDescription = "Description should be maximal {0} characters different as white space!";

        public const string InvalidUrl = "Invalid URL!";

        public const string InvalidPrice = "Invalid Price!";

        public const string InvalidCategory = "Invalid Category";

        public const string InvalidGender = "Invalid Gender!";

        public const string UsernameAlreadyExist = "User with '{0}' username already exists!";

        public const string EmailAlreadyExist = "User with '{0}' e-mail already exists!";

        public const string InvalidUsernameLength = "Username schould be between {0} and {1} characters!";

        public const string InvalidEmail = "Invalid E-Mail address!";

        public const string InvalidPasswordLength = "Password schould be between {0} and {1} characters!";

        public const string PasswordDoesNotMath = "The confirmation password doesn't match the password!";

        public const string EmailValidationPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
