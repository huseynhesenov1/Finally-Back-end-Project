using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
    public class CatagoryWriteRepository : WriteRepository<Catagory>, ICatagoryWriteRepository
    {
        public CatagoryWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
