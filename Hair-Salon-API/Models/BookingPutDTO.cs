
namespace Hair_Salon_API.Models
{
    public class BookingPutDTO
    {
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public int BarberId { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Paid { get; set; }
    }
}
