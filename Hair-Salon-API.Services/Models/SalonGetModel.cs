﻿
using Hair_Salon_API.DAL.Models;

namespace Hair_Salon_API.Services.Models
{
    public class SalonGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Image { get; set; }

        public AddressModel Address { get; set; }
        public decimal? Rating { get; set; }

        public string Description { get; set; } = null!;
        public string? Logo { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
