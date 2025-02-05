using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
    public class OurServiceReadRepository : ReadRepository<OurService>, IOurServiceReadRepository
    {
        public OurServiceReadRepository(AppDbContext context) : base(context)
        {
        }
    }
} 