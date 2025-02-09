using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
	public class VacancyWriteRepository : WriteRepository<Vacancy>, IVacancyWriteRepository
	{
		public VacancyWriteRepository(AppDbContext context) : base(context)
		{
		}
	}
}
