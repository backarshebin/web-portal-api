using AutoMapper;
using portal_domain;
namespace MyWebAPI
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
