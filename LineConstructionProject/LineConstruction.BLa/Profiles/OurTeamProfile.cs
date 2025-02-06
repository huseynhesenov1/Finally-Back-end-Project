using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
	public class OurTeamProfile :Profile
	{
        public OurTeamProfile()
        {
            CreateMap<OurTeamDTO, OurTeam>();
            CreateMap<OurTeamDTO, OurTeam>().ReverseMap();
        }
    }
}
