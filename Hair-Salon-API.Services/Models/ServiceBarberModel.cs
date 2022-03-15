
namespace Hair_Salon_API.Services.Models
{
    public class ServiceBarberModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int BarberId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
