
namespace Hair_Salon_API.DAL.Models
{
    public partial class ServiceBarber
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int BarberId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Barber Barber { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
