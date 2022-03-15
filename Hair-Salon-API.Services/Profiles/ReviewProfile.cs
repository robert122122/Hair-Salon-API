using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Profiles
{
    public class ReviewProfile:Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewModel, Review>().ReverseMap();
        }
    }
}
