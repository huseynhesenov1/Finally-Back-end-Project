using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Utilities;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Repositories.Abstractions;
using LineConstruction.DAL.Repositories.Implementations;

namespace LineConstruction.BLa.Services.Implementations
{
    public class OurTeamService : IOurTeamService
    {
        private readonly IOurTeamReadRepository _ourTeamReadRepo;
        private readonly IOurTeamWriteRepository _ourTeamWriteRepo;
        private readonly IMapper _mapper;

        public OurTeamService(IOurTeamWriteRepository ourTeamWriteRepo, IOurTeamReadRepository ourTeamReadRepo, IMapper mapper)
        {
            _ourTeamWriteRepo = ourTeamWriteRepo;
            _ourTeamReadRepo = ourTeamReadRepo;
            _mapper = mapper;
        }

        public async Task<OurTeam> CreateAsync(OurTeamDTO ourTeamDTO)
        {
            OurTeam ourTeam = _mapper.Map<OurTeam>(ourTeamDTO);
            ourTeam.CreateAt = DateTime.Now;
            ourTeam.ImagePath = await ourTeamDTO.ImagePath.SaveAsync("Teams");
            var res = await _ourTeamWriteRepo.CreateAsync(ourTeam);
            await _ourTeamWriteRepo.SaveChangeAsync();
            return res;

        }
        public async Task<OurTeam> UpdateAsync(OurTeamUpdateDTO ourTeamUpdateDTO)
        {
            OurTeam oldOurTeam = await _ourTeamReadRepo.GetByIdAsync(ourTeamUpdateDTO.Id, false);
            if (oldOurTeam is null)
            {
                throw new Exception("Bu Id-ye uygun deyer tapilmadi");
            }
            OurTeam ourTeam = _mapper.Map<OurTeam>(ourTeamUpdateDTO);
            ourTeam.UpdateAt = DateTime.UtcNow.AddHours(4);
            ourTeam.CreateAt = oldOurTeam.CreateAt;
            if (ourTeamUpdateDTO.ImagePath is not null)
            {
                ourTeam.ImagePath = await ourTeamUpdateDTO.ImagePath.SaveAsync("Teams");
            }
            else
            {
                ourTeam.ImagePath = oldOurTeam.ImagePath;
            }
            var res = _ourTeamWriteRepo.Update(ourTeam);
            if (ourTeamUpdateDTO.ImagePath is not null)
            {
                File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "Teams", oldOurTeam.ImagePath));
            }
            await _ourTeamWriteRepo.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<OurTeam>> GetAllAsync()
        {
            return await _ourTeamReadRepo.GetAllAsync(false, "OurService");
        }
        public async Task<ICollection<OurTeam>> GetAllDeletedAsync()
        {
            return await _ourTeamReadRepo.GetAllAsync(true, "OurService");
        }
        public async Task<OurTeam> GetByIdAsync(int id)
        {
            OurTeam ourTeam = await _ourTeamReadRepo.GetByIdAsync(id, true, "OurService");
            if (ourTeam is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            return ourTeam;
        }

        public async Task<OurTeam> RestoreAsync(int id)
        {
            OurTeam ourTeam = await _ourTeamReadRepo.GetByIdAsync(id, true, "OurService");
            if (ourTeam is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _ourTeamWriteRepo.Restore(ourTeam);
            await _ourTeamWriteRepo.SaveChangeAsync();
            return res;
        }

        public async Task<OurTeam> SoftDeleteAsync(int id)
        {
            OurTeam ourTeam = await _ourTeamReadRepo.GetByIdAsync(id, true, "OurService");
            if (ourTeam is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _ourTeamWriteRepo.Delete(ourTeam);
            await _ourTeamWriteRepo.SaveChangeAsync();
            //File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads" , "Teams" ,ourTeam.ImagePath));
            return res;
        }

    }
}
