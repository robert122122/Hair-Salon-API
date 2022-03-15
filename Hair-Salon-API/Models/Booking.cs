using Hair_Salon_API.DAL.Models;

namespace Hair_Salon_API.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public int BarberId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingChanged { get; set; }
        public bool Paid { get; set; }

        public virtual Barber Barber { get; set; } = null!;
        public virtual Salon Salon { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
