using System;
using System.Collections.Generic;

namespace Hair_Salon_API.DAL.Models
{
    public partial class Salon
    {
        public Salon()
        {
            Barbers = new HashSet<Barber>();
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Image { get; set; }
        public int? AddressId { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string? Password { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<Barber> Barbers { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
