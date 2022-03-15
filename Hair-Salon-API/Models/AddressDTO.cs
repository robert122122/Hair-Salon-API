﻿using Hair_Salon_API.DAL.Models;

namespace Hair_Salon_API.Models
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
    }
}
