
namespace Hair_Salon_API.Services.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public int BarberId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingChanged { get; set; }
        public bool Paid { get; set; }
    }
}
