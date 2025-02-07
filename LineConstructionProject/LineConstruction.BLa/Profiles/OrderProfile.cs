using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Profiles
{
	public class OrderProfile :Profile
	{
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
