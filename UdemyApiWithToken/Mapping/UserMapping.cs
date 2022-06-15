using AutoMapper;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserResource>();
            CreateMap<UserResource, User>();
        }
    }
}
