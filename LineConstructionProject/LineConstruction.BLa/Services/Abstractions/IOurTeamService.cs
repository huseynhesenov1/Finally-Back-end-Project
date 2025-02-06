using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IOurTeamService
	{
		Task<ICollection<OurTeam>> GetAllAsync();
		Task<ICollection<OurTeam>> GetAllDeletedAsync();
		Task<OurTeam> CreateAsync(OurTeamDTO ourTeamDTO);
		Task<OurTeam> UpdateAsync(OurTeamUpdateDTO ourTeamUpdateDTO);
		Task<OurTeam> GetByIdAsync(int id);
		Task<OurTeam> SoftDeleteAsync(int id);
		Task<OurTeam> RestoreAsync(int id);
	}
}
