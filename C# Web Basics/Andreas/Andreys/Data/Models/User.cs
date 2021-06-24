﻿namespace Andreys.Data.Models
{
    using System;
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
        [StringLength(10, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
