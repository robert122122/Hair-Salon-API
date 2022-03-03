using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;
using AutoMapper;

namespace Hair_Salon_API.Profiles
{
    public class BarberProfile:Profile
    {
        public BarberProfile()
        {
            CreateMap<BarberModel, BarberDTO>().ReverseMap();
            CreateMap<BarberModel, BarberPostDTO>().ReverseMap();
            CreateMap<BarberModel, BarberPutDTO>().ReverseMap();
        }
    }
}
