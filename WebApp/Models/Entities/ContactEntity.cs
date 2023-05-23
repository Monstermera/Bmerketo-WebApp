using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Company { get; set; }
        public string Message { get; set; } = null!;
    }
}
