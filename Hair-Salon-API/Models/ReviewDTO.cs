
namespace Hair_Salon_API.Models
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Text { get; set; } = null!;
    }
}
