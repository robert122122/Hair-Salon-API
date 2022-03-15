using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UserModel, UserPostDTO>().ReverseMap();
        }
    }
}
