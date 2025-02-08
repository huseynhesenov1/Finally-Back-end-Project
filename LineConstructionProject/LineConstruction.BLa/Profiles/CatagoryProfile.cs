using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
    public class CatagoryProfile : Profile
    {
        public CatagoryProfile()
        {
            CreateMap<Catagory , CatagoryDTO>();
            CreateMap<Catagory , CatagoryDTO>().ReverseMap();
        }
    }
}
