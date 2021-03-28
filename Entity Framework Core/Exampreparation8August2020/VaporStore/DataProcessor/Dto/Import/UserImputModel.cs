namespace VaporStore.DataProcessor.Dto.Import
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Enums;

    public class UserImputModel
    {
        [Required]
        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<CardInputModel> Cards { get; set; }
    }

    public class CardInputModel
    {
        [Required]
        [RegularExpression("([0-9]{4}) ([0-9]{4}) ([0-9]{4}) ([0-9]{4})")]
        public string Number { get; set; }

        [Required]
        [StringLength(3)]
        public string CVC { get; set; }

        [EnumDataType(typeof(CardType))]
        public CardType Type { get; set; }
    }
}
