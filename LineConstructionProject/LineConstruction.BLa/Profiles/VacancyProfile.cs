using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
	public class VacancyProfile : Profile
	{
        public VacancyProfile()
        {
            CreateMap<Vacancy , VacancyDTO>().ReverseMap();
        }
    }
}
