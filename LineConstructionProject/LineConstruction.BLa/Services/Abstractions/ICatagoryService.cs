using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Services.Abstractions
{
    public interface ICatagoryService
    {
        Task<ICollection<Catagory>> GetAllAsync();
        Task<ICollection<Catagory>> GetAllDeletedAsync();
        Task<Catagory> CreateAsync(CatagoryDTO catagoryDTO);
        Task<Catagory> UpdateAsync(int id, CatagoryDTO catagoryDTO);
        Task<Catagory> GetByIdAsync(int id);
        Task<Catagory> SoftDeleteAsync(int id);
        Task<Catagory> RestoreAsync(int id);
    }
}
