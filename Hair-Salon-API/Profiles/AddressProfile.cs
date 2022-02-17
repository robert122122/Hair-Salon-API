using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Profiles
{
    public class AddressProfile:Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressModel, AddressDTO>().ReverseMap();
            CreateMap<AddressModel, AddressPostDTO>().ReverseMap();
            CreateMap<AddressModel, AddressPutDTO>().ReverseMap();
        }
    }
}
