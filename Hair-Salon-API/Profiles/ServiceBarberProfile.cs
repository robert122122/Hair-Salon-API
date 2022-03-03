using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Profiles
{
    public class ServiceBarberProfile:Profile
    {
        public ServiceBarberProfile()
        {
            CreateMap<ServiceBarberModel, ServiceBarberDTO>().ReverseMap();
        }
    }
}
