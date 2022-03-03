using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
