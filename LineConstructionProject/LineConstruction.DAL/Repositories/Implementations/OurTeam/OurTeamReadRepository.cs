using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations;

public class OurTeamReadRepository : ReadRepository<OurTeam>, IOurTeamReadRepository
{
    public OurTeamReadRepository(AppDbContext context) : base(context)
    {
    }
}
