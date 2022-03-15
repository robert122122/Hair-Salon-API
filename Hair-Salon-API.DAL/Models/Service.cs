
namespace Hair_Salon_API.DAL.Models
{
    public partial class Service
    {
        public Service()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }
        public int ServiceTime { get; set; }
        public int SalonId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Salon Salon { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
