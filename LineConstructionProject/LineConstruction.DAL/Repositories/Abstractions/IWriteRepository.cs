using LineConstruction.Core.Entities;

namespace LineConstruction.DAL.Repositories.Abstractions
{
    public interface IWriteRepository<Tentity> : IRepository<Tentity> where Tentity : BaseEntity, new()
    {
        Task<Tentity> CreateAsync(Tentity tentity);
        Tentity Update(Tentity tentity);
        Tentity Delete(Tentity tentity);
        Tentity Restore(Tentity tentity);
        Task SaveChangeAsync();
    }
}
