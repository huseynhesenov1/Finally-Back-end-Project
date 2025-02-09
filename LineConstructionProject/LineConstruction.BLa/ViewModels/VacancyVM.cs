using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineConstruction.BLa.ViewModels
{
	public class VacancyVM
	{
		public AddedCVCreateDTO? AddedCVCreateDTO { get; set; }
		public ICollection<Vacancy>? Vacancies { get; set; }
	} 
}
