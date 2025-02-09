using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Repositories.Abstractions;
using LineConstruction.DAL.Repositories.Implementations;

namespace LineConstruction.BLa.Services.Implementations
{
	public class VacancyService : IVacancyService
	{
		private readonly IVacancyReadRepository _vacancyReadRepository;
		private readonly IVacancyWriteRepository _vacancyWriteRepository;
		private readonly IMapper _mapper;

		public VacancyService(IMapper mapper, IVacancyWriteRepository vacancyWriteRepository, IVacancyReadRepository vacancyReadRepository)
		{
			_mapper = mapper;
			_vacancyWriteRepository = vacancyWriteRepository;
			_vacancyReadRepository = vacancyReadRepository;
		}

		public async Task<Vacancy> CreateAsync(VacancyDTO vacancyDTO)
		{
			Vacancy vacancy = _mapper.Map<Vacancy>(vacancyDTO);
			vacancy.CreateAt = DateTime.Now;
			vacancy.IsActive = true;
			var res = await _vacancyWriteRepository.CreateAsync(vacancy);
			await _vacancyWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<ICollection<Vacancy>> GetAllAsync()
		{
			return await _vacancyReadRepository.GetAllAsync(false);
		}

		public async Task<ICollection<Vacancy>> GetAllDeletedAsync()
		{
			return await _vacancyReadRepository.GetAllAsync(true);

		}

		public async Task<Vacancy> GetByIdAsync(int id)
		{
			Vacancy vacancy = await _vacancyReadRepository.GetByIdAsync(id, false);
			if (vacancy is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			return vacancy;
		}

		public async Task<Vacancy> RestoreAsync(int id)
		{
			Vacancy vacancy = await _vacancyReadRepository.GetByIdAsync(id, true);
			if (vacancy is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _vacancyWriteRepository.Restore(vacancy);
			await _vacancyWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<Vacancy> SoftDeleteAsync(int id)
		{
			Vacancy vacancy = await _vacancyReadRepository.GetByIdAsync(id, true);
			if (vacancy is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _vacancyWriteRepository.Delete(vacancy);
			await _vacancyWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<Vacancy> UpdateAsync(int id, VacancyDTO vacancyDTO)
		{
			Vacancy vacancy = await _vacancyReadRepository.GetByIdAsync(id, false);
			if (vacancy is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			Vacancy updateVacancy = _mapper.Map<Vacancy>(vacancyDTO);
			updateVacancy.Id = id;
			updateVacancy.CreateAt = vacancy.CreateAt;
			updateVacancy.UpdateAt = DateTime.UtcNow.AddHours(4);
			var res = _vacancyWriteRepository.Update(updateVacancy);
			await _vacancyWriteRepository.SaveChangeAsync();
			return res;
		}
	}
}
