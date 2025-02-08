using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
    public class CatagoryReadRepository : ReadRepository<LineConstruction.Core.Entities.Catagory>, ICatagoryReadRepository
    {
        public CatagoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
