using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public bool Status{get;set;}

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Bill> Bills{get;set;}

    }
}