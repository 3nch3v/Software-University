namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Git.Models;

    public class Commit
    {
        public Commit()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}