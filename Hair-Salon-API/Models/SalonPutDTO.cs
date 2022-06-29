using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Models
{
    public class SalonPutDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Logo { get; set; }
        public string? Image { get; set; } = null!;
    }
}
