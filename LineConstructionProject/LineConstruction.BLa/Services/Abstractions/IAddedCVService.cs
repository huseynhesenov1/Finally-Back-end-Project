using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IAddedCVService
	{
		Task<ICollection<AddedCV>> GetAllAsync();
		Task<ICollection<AddedCV>> GetAllDeletedAsync();
		Task<AddedCV> CreateAsync(AddedCVCreateDTO addedCVCreateDTO);
		Task<AddedCV> GetByIdAsync(int id);
		Task<AddedCV> SoftDeleteAsync(int id);
		Task<AddedCV> RestoreAsync(int id);
	}
}
