using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Profiles
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingModel, Booking>().ReverseMap();
            CreateMap<Booking, BookingGetModel>()
                .ForMember(salon => salon.Salon, opt => opt.MapFrom(s => s.Salon))
                .ForMember(service => service.Service, opt => opt.MapFrom(se => se.Service))
                .ForMember(barber => barber.Barber, opt => opt.MapFrom(b => b.Barber))
                .ReverseMap();
        }
    }
}
