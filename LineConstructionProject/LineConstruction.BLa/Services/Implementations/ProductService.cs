using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Utilities;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.BLa.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IMapper _mapper;
		private readonly IProductReadRepository _productReadRepository;
		private readonly IProductWriteRepository _productWriteRepository;

		public ProductService(IMapper mapper, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
		{
			_mapper = mapper;
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
		}

		public async Task<Product> CreateAsync(ProductCreateDTO productCreateDTO)
		{
			Product product = _mapper.Map<Product>(productCreateDTO);
			product.CreateAt = DateTime.Now;
			product.ImagePath = await productCreateDTO.ImagePath.SaveAsync("Product");
			var res = await _productWriteRepository.CreateAsync(product);
			await _productWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<ICollection<Product>> GetAllAsync()
		{
			return await _productReadRepository.GetAllAsync(false, "Catagory");

		}

		public async Task<ICollection<Product>> GetAllDeletedAsync()
		{
			return await _productReadRepository.GetAllAsync(true, "Catagory");

		}
		public async Task<ICollection<Product>> SearchProductsAsync(string search)
		{
			var query = await _productReadRepository.GetAllAsync(false, "Catagory");

			if (!string.IsNullOrEmpty(search))
			{
				query = query
					.Where(p => p.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
								p.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
					.ToList();
			}

			return query;
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id, true, "Catagory");
			if (product is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			return product;
		}

		public async Task<Product> RestoreAsync(int id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id, true, "Catagory");
			if (product is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _productWriteRepository.Restore(product);
			await _productWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<Product> SoftDeleteAsync(int id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id, true, "Catagory");
			if (product is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _productWriteRepository.Delete(product);
			await _productWriteRepository.SaveChangeAsync();
			//File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads" , "Teams" ,ourTeam.ImagePath));
			return res;
		}

		public async Task<Product> UpdateAsync(ProductUpdateDTO productUpdateDTO)
		{
			Product oldProduct = await _productReadRepository.GetByIdAsync(productUpdateDTO.Id, false);
			if (oldProduct is null)
			{
				throw new Exception("Bu Id-ye uygun deyer tapilmadi");
			}
			Product product = _mapper.Map<Product>(productUpdateDTO);
			product.UpdateAt = DateTime.UtcNow.AddHours(4);
			product.CreateAt = oldProduct.CreateAt;
			if (productUpdateDTO.ImagePath is not null)
			{
				product.ImagePath = await productUpdateDTO.ImagePath.SaveAsync("Product");
			}
			else
			{
				product.ImagePath = oldProduct.ImagePath;
			}
			var res = _productWriteRepository.Update(product);
			if (productUpdateDTO.ImagePath is not null)
			{
				File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "Teams", oldProduct.ImagePath));
			}
			await _productWriteRepository.SaveChangeAsync();
			return res;
		}
	}
}
