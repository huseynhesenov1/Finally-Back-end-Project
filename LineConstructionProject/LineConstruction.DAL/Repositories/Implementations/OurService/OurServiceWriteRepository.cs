using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations {
    public class OurServiceWriteRepository : WriteRepository<OurService>, IOurServiceWriteRepository
    {
        public OurServiceWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
