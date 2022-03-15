
namespace Hair_Salon_API.Models
{
    public class SalonPostDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Image { get; set; }
        public int AddressId { get; set; }
    }
}
