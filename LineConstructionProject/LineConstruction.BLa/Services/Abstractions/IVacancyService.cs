using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IVacancyService
	{
		Task<ICollection<Vacancy>> GetAllAsync();
		Task<ICollection<Vacancy>> GetAllDeletedAsync();
		Task<Vacancy> CreateAsync(VacancyDTO vacancyDTO);
		Task<Vacancy> UpdateAsync(int id, VacancyDTO vacancyDTO);
		Task<Vacancy> GetByIdAsync(int id);
		Task<Vacancy> SoftDeleteAsync(int id);
		Task<Vacancy> RestoreAsync(int id);
	}
}
