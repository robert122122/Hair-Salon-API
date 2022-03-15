using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Profiles
{
    public class ServiceProfile:Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceModel, Service>().ReverseMap();
        }
    }
}
