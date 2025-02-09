using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using LineConstruction.DAL.Repositories.Abstractions;

namespace LineConstruction.DAL.Repositories.Implementations
{
	public class AddedCVWriteRepository : WriteRepository<AddedCV>, IAddedCVWriteRepository
	{
		public AddedCVWriteRepository(AppDbContext context) : base(context)
		{
		}
	}
}
