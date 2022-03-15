
namespace Hair_Salon_API.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
