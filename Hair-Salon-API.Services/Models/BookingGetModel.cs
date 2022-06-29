using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Models
{
    public class BookingGetModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Salon { get; set; }
        public string Service { get; set; }
        public string Barber { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingChanged { get; set; }
        public bool Paid { get; set; }
    }
}
