using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
    public class OurTeamWriteRepository : WriteRepository<OurTeam>, IOurTeamWriteRepository
    {
        public OurTeamWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
