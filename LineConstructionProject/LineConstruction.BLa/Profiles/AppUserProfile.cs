using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AppUser, AppUserLoginDTO>().ReverseMap();
        }
    }
}
