using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Profiles
{
    public class ReviewProfile:Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewModel, ReviewDTO>().ReverseMap();
            CreateMap<ReviewModel, ReviewPostDTO>().ReverseMap();
        }

    }
}
