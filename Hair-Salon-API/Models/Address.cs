using System;
using System.Collections.Generic;

namespace Hair_Salon_API.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int SalonId { get; set; }

        public virtual Salon Salon { get; set; } = null!;
    }
}
