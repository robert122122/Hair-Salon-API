
namespace Hair_Salon_API.Services.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int SalonId { get; set; }
    }
}
