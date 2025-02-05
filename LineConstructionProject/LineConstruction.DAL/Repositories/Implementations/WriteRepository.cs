using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Migrations;
using LineConstruction.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.DAL.Repositories.Implementations
{
    public class WriteRepository<Tentity> : IWriteRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<Tentity> Table => _context.Set<Tentity>();

        public async Task<Tentity> CreateAsync(Tentity tentity)
        {
          await Table.AddAsync(tentity);
            return tentity;
        }

        public Tentity Delete(Tentity tentity)
        {
            if (tentity is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            tentity.IsDeleted = true;
            return tentity;

        }

		public Tentity Restore(Tentity tentity)
		{
			if (tentity is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			tentity.IsDeleted = false;
			return tentity;
		}

		public async Task SaveChangeAsync()
        {
          await  _context.SaveChangesAsync();
            
        }

        public Tentity Update(Tentity tentity)
        {
            Table.Update(tentity);
            return tentity;
        }
    }
}
