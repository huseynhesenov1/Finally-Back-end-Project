using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
	public class VacancyReadRepository : ReadRepository<Vacancy>, IVacancyReadRepository
	{
		public VacancyReadRepository(AppDbContext context) : base(context)
		{
		}
	}
}
