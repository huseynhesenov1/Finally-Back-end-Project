using LineConstruction.Core.Entities;

namespace LineConstruction.DAL.Repositories.Abstractions
{
    public interface IReadRepository<Tentity> : IRepository<Tentity> where Tentity : BaseEntity, new()
    {
        Task<Tentity> GetByIdAsync(int id, bool isTracking, params string[] includes);
        Task<ICollection<Tentity>> GetAllAsync(bool deleted, params string[] includes);
    }
}
