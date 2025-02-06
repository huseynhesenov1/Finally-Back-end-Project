using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
    public class OurServiceUpdateProfile:Profile
    {
        public OurServiceUpdateProfile()
        {
            CreateMap<OurTeamUpdateDTO, OurTeam>();
            CreateMap<OurTeam, OurTeamUpdateDTO>()
            .ForMember(dest => dest.ImagePath, opt => opt.Ignore()).ReverseMap();
        }
    }
}
