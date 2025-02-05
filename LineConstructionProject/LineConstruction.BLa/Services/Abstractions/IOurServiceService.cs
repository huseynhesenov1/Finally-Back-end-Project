using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineConstruction.BLa.Services.Abstractions
{
	public interface IOurServiceService
	{
		Task<ICollection<OurService>> GetAllAsync();
		Task<ICollection<OurService>> GetAllDeletedAsync();
		Task<OurService> CreateAsync(OurServiceDTO ourServiceDTO);
		Task<OurService> UpdateAsync(int id , OurServiceDTO ourServiceDTO);
		Task<OurService> GetByIdAsync(int id);
		Task<OurService> SoftDeleteAsync(int id);
		Task<OurService> RestoreAsync(int id);

	}
}
