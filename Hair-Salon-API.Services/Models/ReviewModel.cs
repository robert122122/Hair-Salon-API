using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Text { get; set; } = null!;
    }
}
