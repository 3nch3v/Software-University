﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


         public ICollection<Team> PrimaryKitTeams { get; set; }

         public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
