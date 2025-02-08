using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;
using System.Net.Http.Headers;

namespace LineConstruction.BLa.Profiles
{
	public class ProductProfile : Profile
	{
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ForMember(dest => dest.ImagePath, opt => opt.Ignore()).ReverseMap();
        }
    }
}
