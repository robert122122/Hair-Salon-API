using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Profiles
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingModel, BookingDTO>().ReverseMap();
            CreateMap<BookingModel, BookingPostDTO>().ReverseMap();
            CreateMap<BookingModel, BookingPutDTO>().ReverseMap();
        }
    }
}
