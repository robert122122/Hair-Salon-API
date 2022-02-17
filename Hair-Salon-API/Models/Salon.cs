using Hair_Salon_API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Barber> Barbers { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
