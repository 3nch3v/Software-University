namespace BattleCards.Common
{
    public static class GlobalConstants
    {
        public const int UsernameMinLength = 5;

        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;

        public const int PasswordMaxLength = 20;

        public const string UsernameAlreadyExist = "User with '{0}' username already exists!";

        public const string EmailAlreadyExist = "User with '{0}' e-mail already exists!";

        public const string InvalidUsernameLength = "Username schould be between {0} and {1} characters!";

        public const string InvalidEmail = "Invalid E-Mail address!";

        public const string InvalidPasswordLength = "Password schould be between {0} and {1} characters!";

        public const string PasswordDoesNotMath = "The confirmation password doesn't match the password!";

        public const int CardMinLength = 5;

        public const int CardMaxLength = 15;

        public const int MaxImageUrlLength = 2048;

        public const int DescriptionMinLength = 1;

        public const int DescriptionMaxLength = 200;

        public const string InvalidCardName = "Name schould be between {0} and {1} characters!";

        public const string InvalidImageUrl = "Invalid Image URL!";

        public const string IvalidKeyword = "Invalid Keyword!";

        public const string IvalidAttackRate = "Invalid Attack rate!";

        public const string IvalidHealthRate = "Invalid Health rate!";

        public const string InvalidDescriptionLength = "Description should be between {0} and {1} characters!";
    }
}
