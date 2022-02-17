using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Profiles
{
    public class AddressProfile:Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressModel, Address>().ReverseMap();
        }

    }
}
