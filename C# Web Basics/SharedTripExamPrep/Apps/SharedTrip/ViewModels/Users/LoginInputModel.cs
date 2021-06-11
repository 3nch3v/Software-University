using System.ComponentModel.DataAnnotations;

namespace SharedTrip.ViewModels.Users
{
    public class LoginInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
