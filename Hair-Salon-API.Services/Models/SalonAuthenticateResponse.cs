using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Models
{
    public class SalonAuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Image { get; set; }

        public string Description { get; set; } = null!;
        public string? Logo { get; set; }
        public string Token { get; set; }


        public SalonAuthenticateResponse(SalonModel salon, string token)
        {
            Id = salon.Id;
            Name = salon.Name;
            PhoneNumber = salon.PhoneNumber;
            Email = salon.Email;
            Image = salon.Image;
            Description = salon.Description;
            Logo = salon.Logo;
            Token = token;
        }
    }
}
