using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IOrderService
    {
		Task<ICollection<Order>> GetAllAsync();
		Task<ICollection<Order>> GetAllDeletedAsync();
		Task<Order> CreateAsync(OrderDTO orderDTO);
		Task<Order> UpdateAsync(int id, OrderDTO orderDTO);
		Task<Order> GetByIdAsync(int id);
		Task<Order> SoftDeleteAsync(int id);
		Task<Order> RestoreAsync(int id);
	}
}
