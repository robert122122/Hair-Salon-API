
namespace Hair_Salon_API.Models
{
    public class SalonGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Image { get; set; }
        public string Address { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
