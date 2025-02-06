using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineConstruction.BLa.Services.Implementations
{
    public class OurServiceService : IOurServiceService
    {
        private readonly IOurServiceReadRepository _ourServiceReadRepository;
        private readonly IOurServiceWriteRepository _ourServiceWriteRepository;
        private readonly IMapper _mapper;

        public OurServiceService(IOurServiceWriteRepository ourServiceWriteRepository, IOurServiceReadRepository ourServiceReadRepository, IMapper mapper)
        {
            _ourServiceWriteRepository = ourServiceWriteRepository;
            _ourServiceReadRepository = ourServiceReadRepository;
            _mapper = mapper;
        }
        public async Task<OurService> GetByIdAsync(int id)
        {
            OurService ourService = await _ourServiceReadRepository.GetByIdAsync(id, false);
            if (ourService is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            return ourService;
        }

        public async Task<OurService> SoftDeleteAsync(int id)
        {
            OurService ourService = await _ourServiceReadRepository.GetByIdAsync(id, true);
            if (ourService is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _ourServiceWriteRepository.Delete(ourService);
            await _ourServiceWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<OurService> CreateAsync(OurServiceDTO ourServiceDTO)
        {
            OurService ourService = _mapper.Map<OurService>(ourServiceDTO);
            ourService.CreateAt = DateTime.UtcNow.AddHours(4);

            var res = await _ourServiceWriteRepository.CreateAsync(ourService);
            await _ourServiceWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<OurService>> GetAllAsync()
        {
            return await _ourServiceReadRepository.GetAllAsync(false);
        }

        public async Task<OurService> UpdateAsync(int id, OurServiceDTO ourServiceDTO)
        {
           OurService ourService = await _ourServiceReadRepository.GetByIdAsync(id, false);
            if (ourService is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            OurService updateOurService = _mapper.Map<OurService>(ourServiceDTO);
            updateOurService.Id = id;
            updateOurService.CreateAt = ourService.CreateAt;
            updateOurService.UpdateAt = DateTime.UtcNow.AddHours(4);
            var res = _ourServiceWriteRepository.Update(updateOurService);
           await _ourServiceWriteRepository.SaveChangeAsync();
            return res;
        }

		public async Task<ICollection<OurService>> GetAllDeletedAsync()
		{
			return await _ourServiceReadRepository.GetAllAsync(true);
		}

		public async Task<OurService> RestoreAsync(int id)
		{
			OurService ourService = await _ourServiceReadRepository.GetByIdAsync(id, true);
			if (ourService is null)
			{
				throw new Exception("Bu Id ye uygun deyer tapilmadi");
			}
			var res = _ourServiceWriteRepository.Restore(ourService);
			await _ourServiceWriteRepository.SaveChangeAsync();
			return res;
		}
	}
}
