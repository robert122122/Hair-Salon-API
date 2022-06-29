using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Profiles
{
    public class SalonProfile:Profile
    {
        public SalonProfile()
        {
            CreateMap<SalonModel, SalonDTO>().ReverseMap();
            CreateMap<SalonModel, SalonPostDTO>().ReverseMap();
            CreateMap<SalonGetModel, SalonGetDTO>().ReverseMap();
            CreateMap<SalonModel, SalonPutDTO>().ReverseMap();

        }
    }
}
