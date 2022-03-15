﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Models
{
    public class ReviewPostDTO
    {
        public int SalonId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; } = null!;
    }
}
