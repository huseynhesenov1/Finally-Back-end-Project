using LineConstruction.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.DAL.Repositories.Abstractions
{
    public interface IRepository<Tentity> where Tentity : BaseEntity, new()
    {
        public DbSet<Tentity> Table { get; }
    }
}
