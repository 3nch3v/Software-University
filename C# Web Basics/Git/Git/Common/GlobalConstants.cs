namespace Git.Common
{
    public static class GlobalConstants
    {
        public const int UsernameMinLength = 5;

        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;

        public const int PasswordMaxLength = 20;

        public const int CommitDescriptionMinLength = 5;

        public const int RepositoryNameMinLength = 3;

        public const int RepositoryNameMaxLength = 10;

        public const string PublicType = "Public";

        public const string PrivateType = "Private";

        public const string InvalidRepositoryType = "Invalid repository type!";

        public const string InvalidRepositoryName = "Repository name should be between {0} and {1} characters!";

        public const string InvalidCommitDescription = "Commit description should be bigger than 5 characters!";

        public const string UsernameAlreadyExist = "User with '{0}' username already exists!";

        public const string EmailAlreadyExist = "User with '{0}' e-mail already exists!";

        public const string InvalidUsernameLength = "Username schould be between {0} and {1} characters!";

        public const string InvalidEmail = "Invalid E-Mail address!";

        public const string InvalidPasswordLength = "Password schould be between {0} and {1} characters!";

        public const string PasswordDoesNotMath = "The confirmation password doesn't match the password!";

        public const string EmailValidationPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
