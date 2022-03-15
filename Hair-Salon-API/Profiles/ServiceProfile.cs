using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Profiles
{
    public class ServiceProfile:Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceModel, ServiceDTO>().ReverseMap();
            CreateMap<ServiceModel, ServicePostDTO>().ReverseMap();
            CreateMap<ServiceModel, ServicePutDTO>().ReverseMap();
        }
    }
}
