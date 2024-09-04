namespace Core.Entities
{
    public class Contact : BaseEntity
    { 
        // public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

    }
}