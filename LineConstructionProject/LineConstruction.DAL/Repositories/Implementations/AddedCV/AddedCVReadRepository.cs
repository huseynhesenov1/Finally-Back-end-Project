using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
	public class AddedCVReadRepository : ReadRepository<AddedCV>, IAddedCVReadRepository
	{
		public AddedCVReadRepository(AppDbContext context) : base(context)
		{
		}
	}
}
