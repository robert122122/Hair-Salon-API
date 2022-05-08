namespace Hair_Salon_API.Models
{
    public class ReviewGetDTO
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Text { get; set; } = null!;
    }
}
