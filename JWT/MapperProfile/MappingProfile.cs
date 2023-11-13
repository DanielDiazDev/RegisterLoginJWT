using AutoMapper;
using RegisterLoginJWT.Model;
using RegisterLoginJWT.Model.DTOs;

namespace RegisterLoginJWT.API.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, LoginResultDTO>().ReverseMap();
        }
    }
}
