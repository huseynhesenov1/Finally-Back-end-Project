using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
	public class OurServiceProfile : Profile
	{
        public OurServiceProfile()
        {
            CreateMap<OurServiceDTO, OurService>();
            CreateMap<OurServiceDTO, OurService>().ReverseMap();
        }
    }
}
