namespace CarShop.Common
{
    public class GlobalConstants
    {
        public const int UsernameMinLength = 4;

        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 5;

        public const int PasswordMaxLength = 20;

        public const string MechanicType = "Mechanic";

        public const string ClientType = "Client";

        public const string UsernameAlreadyExist = "User with '{0}' username already exists!";

        public const string EmailAlreadyExist = "User with '{0}' e-mail already exists!";

        public const string InvalidUsernameLength = "Username schould be between {0} and {1} characters!";

        public const string InvalidEmail = "Invalid E-Mail address!";

        public const string InvalidPasswordLength = "Password schould be between {0} and {1} characters!";

        public const string PasswordDoesNotMath = "The confirmation password doesn't match the password!";

        public const string InvalidUserType = "Invalid user type!";

        public const int CarModelMaxLength = 20;

        public const int CarModelMinLength = 5;

        public const int PictureUrlMaxLength = 2048;

        public const int MinYear = 1900;

        public const string PlateNumberRegexPattern = "[A-Z]{2}[0-9]{4}[A-Z]{2}";

        public const string InvalidCarModelLength = "Model schould be between {0} and {1} characters!";

        public const string InvalidPictureUrl = "Invalid image URL!";

        public const string InvalidPlateNumber = "Invalid plate number!";

        public const string InvalidYear = "Invalid year!";

    }
}
