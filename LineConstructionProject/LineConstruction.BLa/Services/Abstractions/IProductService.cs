using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IProductService
	{
		Task<ICollection<Product>> GetAllAsync();
		Task<ICollection<Product>> SearchProductsAsync(string search);
		Task<ICollection<Product>> GetAllDeletedAsync();
		Task<Product> CreateAsync(ProductCreateDTO productCreateDTO);
		Task<Product> UpdateAsync(ProductUpdateDTO productUpdateDTO);
		Task<Product> GetByIdAsync(int id);
		Task<Product> SoftDeleteAsync(int id);
		Task<Product> RestoreAsync(int id);
	}
}
