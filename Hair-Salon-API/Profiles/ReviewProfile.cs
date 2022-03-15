using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;

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
