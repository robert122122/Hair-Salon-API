using System;
using System.Collections.Generic;

namespace Hair_Salon_API.Models
{
    public partial class Salon
    {
        public Salon()
        {
            Addresses = new HashSet<Address>();
            Barbers = new HashSet<Barber>();
            Bookings = new HashSet<Booking>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Image { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Barber> Barbers { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
