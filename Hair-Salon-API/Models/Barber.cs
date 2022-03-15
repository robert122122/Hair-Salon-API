using Hair_Salon_API.DAL.Models;

namespace Hair_Salon_API.Models
{
    public partial class Barber
    {
        public Barber()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int SalonId { get; set; }
        public string? Image { get; set; }

        public virtual Salon Salon { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
