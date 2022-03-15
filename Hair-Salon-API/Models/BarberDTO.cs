﻿
namespace Hair_Salon_API.Models
{
    public class BarberDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public int SalonId { get; set; }
        public string? Image { get; set; }
    }
}
