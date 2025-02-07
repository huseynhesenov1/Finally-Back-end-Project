using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;
using LineConstruction.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.BLa.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IOrderReadRepository _orderReadRepository;
		private readonly IOrderWriteRepository _orderWriteRepository;
		private readonly IOurTeamReadRepository _ourTeamReadRepository;
		private readonly IMapper _mapper;

		public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IMapper mapper, IOurTeamReadRepository ourTeamReadRepository)
		{
			_orderReadRepository = orderReadRepository;
			_orderWriteRepository = orderWriteRepository;
			_mapper = mapper;
			_ourTeamReadRepository = ourTeamReadRepository;
		}

		public async Task<Order> CreateAsync(OrderDTO orderDTO)
		{
			Order order = _mapper.Map<Order>(orderDTO);
			order.CreateAt = DateTime.Now;
			var mostExperiencedTeam = (await _ourTeamReadRepository.GetAllAsync(false)).ToList().OrderByDescending(t => t.ExperienceYear)
	.FirstOrDefault();
			if (mostExperiencedTeam != null)
			{
				order.OurTeamId = mostExperiencedTeam.Id;
			}
			var res = await _orderWriteRepository.CreateAsync(order);
			await _orderWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<ICollection<Order>> GetAllAsync()
		{
			return await _orderReadRepository.GetAllAsync(false, ["OurService","OurTeam"]);
		}

		public async Task<ICollection<Order>> GetAllDeletedAsync()
		{
			return await _orderReadRepository.GetAllAsync(true, ["OurTeam", "OurService"]);
		}

		

		public async Task<Order> RestoreAsync(int id)
		{
			Order order = await _orderReadRepository.GetByIdAsync(id, true);
			if (order is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _orderWriteRepository.Restore(order);
			await _orderWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<Order> GetByIdAsync(int id)
		{
			Order order = await _orderReadRepository.GetByIdAsync(id, false, ["OurTeam", "OurService"]);
			if (order is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			return order;
		}

		public async Task<Order> SoftDeleteAsync(int id)
		{
			Order order = await _orderReadRepository.GetByIdAsync(id, true);
			if (order is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _orderWriteRepository.Delete(order);
			await _orderWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<Order> UpdateAsync(int id, OrderDTO orderDTO)
		{
			Order order = await _orderReadRepository.GetByIdAsync(id, false);
			if (order is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			Order updateOrder = _mapper.Map<Order>(orderDTO);
			updateOrder.Id = id;
			updateOrder.CreateAt = order.CreateAt;
			updateOrder.UpdateAt = DateTime.UtcNow.AddHours(4);
			var res = _orderWriteRepository.Update(updateOrder);
			await _orderWriteRepository.SaveChangeAsync();
			return res;
		}
	}



}
