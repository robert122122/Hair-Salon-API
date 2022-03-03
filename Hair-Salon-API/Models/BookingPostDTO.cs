using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Models
{
    public class BookingPostDTO
    {
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public int BarberId { get; set; }
        public DateTime BookingDate { get; set; }
        public int UserId { get; set; }
    }
}
