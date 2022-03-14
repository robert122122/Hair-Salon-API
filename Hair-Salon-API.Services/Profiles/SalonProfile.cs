using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Profiles
{
    public class SalonProfile:Profile
    {
        public SalonProfile()
        {
            CreateMap<Salon, SalonModel>().ReverseMap();
            CreateMap<Salon, SalonGetModel>()
            .ForMember(address => address.Address, opt => opt.MapFrom(b => b.Address.City))
            .ReverseMap();
        }

    }
}
