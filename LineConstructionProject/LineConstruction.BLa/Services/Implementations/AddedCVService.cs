using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Utilities;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Repositories.Abstractions;
using LineConstruction.DAL.Repositories.Implementations;

namespace LineConstruction.BLa.Services.Implementations
{
	public class AddedCVService : IAddedCVService
	{
		private readonly IAddedCVReadRepository _addedCVReadRepository;
		private readonly IAddedCVWriteRepository _addedCVWriteRepository;
		private readonly IMapper _mapper;

		public AddedCVService(IMapper mapper, IAddedCVWriteRepository addedCVWriteRepository, IAddedCVReadRepository addedCVReadRepository)
		{
			_mapper = mapper;
			_addedCVWriteRepository = addedCVWriteRepository;
			_addedCVReadRepository = addedCVReadRepository;
		}

		public async Task<AddedCV> CreateAsync(AddedCVCreateDTO addedCVCreateDTO)
		{
			AddedCV addedCV = _mapper.Map<AddedCV>(addedCVCreateDTO);
			addedCV.CreateAt = DateTime.Now;
			addedCV.CvPath = await addedCVCreateDTO.CvPath.SaveAsync("CV");
			var res = await _addedCVWriteRepository.CreateAsync(addedCV);
			await _addedCVWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<ICollection<AddedCV>> GetAllAsync()
		{
			return await _addedCVReadRepository.GetAllAsync(false);
		}

		public async Task<ICollection<AddedCV>> GetAllDeletedAsync()
		{
			return await _addedCVReadRepository.GetAllAsync(true);

		}

		public async Task<AddedCV> GetByIdAsync(int id)
		{
			AddedCV addedCV = await _addedCVReadRepository.GetByIdAsync(id, false);
			if (addedCV is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			return addedCV;
		}

		public async Task<AddedCV> RestoreAsync(int id)
		{
			AddedCV addedCV = await _addedCVReadRepository.GetByIdAsync(id, true);
			if (addedCV is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _addedCVWriteRepository.Restore(addedCV);
			await _addedCVWriteRepository.SaveChangeAsync();
			return res;
		}

		public async Task<AddedCV> SoftDeleteAsync(int id)
		{
			AddedCV addedCV = await _addedCVReadRepository.GetByIdAsync(id, true);
			if (addedCV is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _addedCVWriteRepository.Delete(addedCV);
			await _addedCVWriteRepository.SaveChangeAsync();
			return res;
		}
	}
}
