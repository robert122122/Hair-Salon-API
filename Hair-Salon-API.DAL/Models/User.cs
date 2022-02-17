using System;
using System.Collections.Generic;

namespace Hair_Salon_API.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
