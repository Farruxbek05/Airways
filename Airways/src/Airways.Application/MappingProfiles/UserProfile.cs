using Airways.Application.Models.User;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, ApplicationUser>();
        }
    }
}
