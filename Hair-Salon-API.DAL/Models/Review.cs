
namespace Hair_Salon_API.DAL.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Text { get; set; } = null!;

        public virtual Salon Salon { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
