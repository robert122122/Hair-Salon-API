﻿
namespace Hair_Salon_API.Models
{
    public class BarberPutDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string? Image { get; set; }
    }
}
