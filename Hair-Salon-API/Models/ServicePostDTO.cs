
namespace Hair_Salon_API.Models
{
    public class ServicePostDTO
    {
        public string ServiceName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }
        public int ServiceTime { get; set; }
        public int SalonId { get; set; }
    }
}
