using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Contact : BaseEntity
    { 
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        [MaxLength(12)]
        public required string PhoneNumber { get; set; }

    }
}