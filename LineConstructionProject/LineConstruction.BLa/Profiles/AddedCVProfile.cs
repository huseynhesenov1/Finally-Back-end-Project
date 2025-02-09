using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
	public class AddedCVProfile : Profile
	{
        public AddedCVProfile()
        {
            CreateMap<AddedCV , AddedCVCreateDTO>().ReverseMap();
        }
    }
}
