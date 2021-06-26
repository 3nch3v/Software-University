namespace Panda.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Package> Packages  { get; set; } = new HashSet<Package>();

        public ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
