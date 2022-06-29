
namespace Hair_Salon_API.Services.Models
{
    public class SalonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Image { get; set; }
        public string City { get; set; }

        public string Description { get; set; } = null!;
        public string? Logo { get; set; }

        public string Password { get; set; }
    }
}
